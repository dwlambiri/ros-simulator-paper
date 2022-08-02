
#define diff_membrane_index 2
#define diff_membrane_dead_index 3
#define diff_dead_index 4
#define diff_dead_z_index 8
#define diff_membrane_stress_index 9

#define AXON_HEALTHY 1
#define AXON_STRESS 2
#define AXON_DEAD 0

#define AXON_DISPLAY_HEALTHY 1
#define AXON_DISPLAY_STRESS 2
#define AXON_DISPLAY_DEAD 0

#define NOTOXCONST -1

/*
* [DWL]
* Axon states:
* AXON_HEALTHY --> AXON_STRESS --> AXON_DEAD
*/

/*
* [DWL] Need to keep the constants in this file in line with the values in preprocess.cs!!
		 private readonly byte rate_zero_index = 0;
        private readonly byte rate_live_index = 1;
        private readonly byte rate_membrane_index = 2;
        private readonly byte rate_membrane_dead_index = 3;
        private readonly byte rate_dead_index = 4;
        private readonly byte rate_extra_index = 5;
        private readonly byte rate_live_z_index = 6;
        private readonly byte rate_extra_z_index = 7;
        private readonly byte rate_dead_z_index = 8;
        private readonly byte rate_membrane_stress_index = 9;
        private readonly byte rate_tissue_index_xy = 10;
        private readonly byte rate_tissue_index_z = 11;
        private readonly byte rate_one_index = 12;
        private readonly byte rate_values_size = 13
*/

extern "C" __global__  void cuda_rgc_update_live(int n_axons, float* tox, unsigned char* rate, float* detox, float* tox_prod, float k_detox_extra, float* h2sThrVector_dev,
	unsigned int * axons_cent_pix, unsigned int* axons_inside_pix, unsigned int* axons_inside_pix_idx, unsigned int* axon_surr_rate, unsigned int* axon_surr_rate_idx,
	unsigned char* axon_state, unsigned char* axon_mask, int* num_alive_axons, int* num_stress_axons, int* death_itr, int iteration, int offset, int pixelNeighbourNumbers, float deathDetox, unsigned int* axon_death_timer, unsigned int iterToDeath,
	float* hProdVector_dev, float* sProdVector_dev, float* s2hThrVector_dev, float* s2dThrVector_dev, int timer_reset)
{
	int n = threadIdx.x + blockIdx.x * blockDim.x;

	if (n < n_axons)
	{
		// [DWL]: I made death_tox_threshold to be an array INSTEAD of a constant 
		//			This way we can set the death threshold DIFFERENTLY for each axon
		//			The death is calculated at the head of the axon
		if (axon_state[n] == AXON_STRESS) {
			if (axon_death_timer[n] > iterToDeath || tox[offset + axons_cent_pix[n]] >= s2dThrVector_dev[n]) {
				// kill the axon if either timer expires or if the threshold is larger than preset value
				int next = axons_inside_pix_idx[n + 1];
				for (int p = axons_inside_pix_idx[n]; p < next; p++)
				{
					int idx = axons_inside_pix[p];
					tox_prod[idx] = NOTOXCONST;
					detox[idx] = deathDetox;
					axon_mask[idx] = AXON_DISPLAY_DEAD; // dead axon display mask
				}
				next = axon_surr_rate_idx[n + 1];
				for (int p = axon_surr_rate_idx[n], i = 0; p < next; p++, i++) {
					unsigned int index = axon_surr_rate[p];
					if (index != 0) {
						unsigned char c = rate[index];
						if ((i % pixelNeighbourNumbers) < 4) {
							if (c == diff_membrane_index  || c == diff_membrane_stress_index)
								c = diff_membrane_dead_index;
							else
								c = diff_dead_index;
						}
						else
							c = diff_dead_z_index;
						rate[index] = c;
					}
				}

				axon_state[n] = AXON_DEAD;
			    death_itr[n] = iteration;
			    atomicAdd(&num_alive_axons[0], -1);
				atomicAdd(&num_stress_axons[0], -1);
			}
			else {
				

				if (tox[offset + axons_cent_pix[n]] <= s2hThrVector_dev[n])
				{ 	// Move axon back to healthy state
					
					if(timer_reset) axon_death_timer[n] = 0;

					int next = axons_inside_pix_idx[n + 1];
					for (int p = axons_inside_pix_idx[n]; p < next; p++)
					{
						int idx = axons_inside_pix[p];


						if (tox_prod[idx] >= 0) {
							tox_prod[idx] = hProdVector_dev[n];
						}
						
						axon_mask[idx] = AXON_DISPLAY_HEALTHY; // healthy axon display mask

					}
					next = axon_surr_rate_idx[n + 1];
#if 0
					for (int p = axon_surr_rate_idx[n], i = 0; p < next; p++, i++) {
						unsigned int index = axon_surr_rate[p];
						if (index != 0) {
							unsigned char c = rate[index];
							if ((i % pixelNeighbourNumbers) < 4) {
								if (c == diff_membrane_stress_index)
									c = diff_membrane_index;
							}
							rate[index] = c;
						}
					}
#endif					
					axon_state[n] = AXON_HEALTHY;
					atomicAdd(&num_stress_axons[0], -1);
				}
				else {
					// increment death timer
					axon_death_timer[n]++;
				}

			}
		}
		else if (axon_state[n] == AXON_HEALTHY)
		{ 	
			if (tox[offset + axons_cent_pix[n]] >= h2sThrVector_dev[n]) {
				// Move the axon to Stress state
				int next = axons_inside_pix_idx[n + 1];
				for (int p = axons_inside_pix_idx[n]; p < next; p++)
				{
					int idx = axons_inside_pix[p];

					if (tox_prod[idx] >= 0) {
						tox_prod[idx] = sProdVector_dev[n];
					}

					axon_mask[idx] = AXON_DISPLAY_STRESS; // stressed axon for display

				}
				next = axon_surr_rate_idx[n + 1];
#if 0
				for (int p = axon_surr_rate_idx[n], i = 0; p < next; p++, i++) {
					unsigned int index = axon_surr_rate[p];
					if (index != 0) {
						unsigned char c = rate[index];
						if ((i % pixelNeighbourNumbers) < 4) {
							if (c == diff_membrane_index)
								c = diff_membrane_stress_index;
						}
						rate[index] = c;
					}
				}
#endif
				axon_state[n] = AXON_STRESS;
				axon_death_timer[n]++;
				atomicAdd(&num_stress_axons[0], +1);
			}
			else {
				if(axon_death_timer[n] > 0) axon_death_timer[n]--;
			}
			
		}
	}
}

