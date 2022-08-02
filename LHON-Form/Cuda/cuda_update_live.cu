
#define diff_dead_index 4
#define diff_dead_z_index 8

/*
* [DWL] Need to keep the constants in this file in line with the values in preprocess.cs!!
		private readonly byte rate_zero_index = 0;
		private readonly byte rate_live_index = 1;
		private readonly byte rate_membrane_index = 2;
		private readonly byte rate_UNUSED_index = 3;
		private readonly byte rate_dead_index = 4;
		private readonly byte rate_extra_index = 5;
		private readonly byte rate_live_z_index = 6;
		private readonly byte rate_extra_z_index = 7;
		private readonly byte rate_dead_z_index = 8;
		private readonly byte rate_one_index = 9;
		private readonly byte rate_values_size = 10;
*/

extern "C" __global__  void cuda_update_live(int n_axons, float* tox, unsigned char* rate, float* detox, float* tox_prod, float on_death_tox, float k_detox_extra, float* death_tox_thres,
	unsigned int * axons_cent_pix, unsigned int* axons_inside_pix, unsigned int* axons_inside_pix_idx, unsigned int* axon_surr_rate, unsigned int* axon_surr_rate_idx,
	unsigned char* axon_state, unsigned char* axon_mask, int* num_alive_axons, int* death_itr, int iteration, int offset, int pixelNeighbourNumbers, float deathDetox, unsigned int* axon_death_timer, unsigned int iterToDeath)
{
	int n = threadIdx.x + blockIdx.x * blockDim.x;

	if (n < n_axons)
	{
		// [DWL]: I made death_tox_threshold to be an array INSTEAD of a constant 
		//			This way we can set the death threshold DIFFERENTLY for each axon
		//			The death is calculated at the head of the axon
		if (axon_state[n] == 2) {
			if (axon_death_timer[n] == 0) {

				for (int p = axons_inside_pix_idx[n]; p < axons_inside_pix_idx[n + 1]; p++)
				{
					int idx = axons_inside_pix[p];
					tox_prod[idx] = 0;
					detox[idx] = deathDetox;
					axon_mask[idx] = 3; // dead for display
				}
				axon_state[n] = 0;
			    death_itr[n] = iteration;
			    atomicAdd(&num_alive_axons[0], -1);
			}
			else {
				axon_death_timer[n]--;
			}
		}
		else if (axon_state[n] == 1 && tox[offset+axons_cent_pix[n]] >= death_tox_thres[n])
		{ 	// Kill the axon
			for (int p = axons_inside_pix_idx[n]; p < axons_inside_pix_idx[n + 1]; p++)
			{
				int idx = axons_inside_pix[p];

				
				//tox[offset+idx] += on_death_tox;
				if (tox_prod[idx] > 0) {
					tox_prod[idx] = on_death_tox;
				}
				//else {
					//detox[idx] = deathDetox;
				//}
				axon_mask[idx] = 2; // apoptotic for display
				
				/*
				int idxN = pixelNeighbourNumbers * idx;
				for (int i = 0; i < pixelNeigbourNumbers; i++) {
					rate[idxN + i] = diff_dead_index;
				}
				*/
				
			}

			for (int p = axon_surr_rate_idx[n], i = 0; p < axon_surr_rate_idx[n + 1]; p++, i++) {
				if (axon_surr_rate[p] != 0) {
					if ((i % pixelNeighbourNumbers) < 4)
						rate[axon_surr_rate[p]] = diff_dead_index;
					else
						rate[axon_surr_rate[p]] = diff_dead_z_index;
				}
			}
			
			//axon_state[n] = 0;
			//death_itr[n] = iteration;
			//atomicAdd(&num_alive_axons[0], -1);
			axon_state[n] = 2;
			axon_death_timer[n] = iterToDeath;
		}
	}
}

