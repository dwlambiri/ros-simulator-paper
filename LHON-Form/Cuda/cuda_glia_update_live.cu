
#define diff_membrane_index 2
#define diff_membrane_dead_index 3
#define diff_dead_index 4
#define diff_dead_z_index 8
#define diff_membrane_stress_index 9

#define GLIA_HEALTHY 1
#define GLIA_STRESS 2
#define GLIA_DEAD 0

#define GLIA_DISPLAY_HEALTHY 5
#define GLIA_DISPLAY_STRESS 6
#define GLIA_DISPLAY_DEAD 4

/*
* [DWL]
* Glia states:
* GLIA_HEALTHY --> GLIS_STRESS --> GLIA_DEAD
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
        private readonly byte rate_one_index = 10;
        private readonly byte rate_values_size = 11;
*/


extern "C" __global__  void cuda_glia_update_live(int n_glias, float* tox, float* detox, float* tox_prod, float k_stress_glia_tox_prod, float k_healthy_glia_tox_prod, float h2s_tox_thres, float s2d_tox_thres, float s2h_tox_thres,
	unsigned int* glia_center, unsigned char* glia_state, unsigned int* glia_death_timer, unsigned char* simulation_mask, int offset, float k_death_glia_detox, unsigned int iterToDeath , int timer_reset)
{
	int n = threadIdx.x + blockIdx.x * blockDim.x;

	// [DWL] states: 0 == dead, 1== alive, 2 == stress

	if (n < n_glias)
	{
		// [DWL]: 
		int center = glia_center[n];
		if (glia_state[n] == GLIA_STRESS) {
			if (glia_death_timer[n] > iterToDeath || tox[offset + center] >=  s2d_tox_thres) {
				glia_state[n] = GLIA_DEAD; //dead
				tox_prod[center] = -1;
				detox[center] = k_death_glia_detox;
				simulation_mask[center] = GLIA_DISPLAY_DEAD; // for display
			}
			else if(tox[offset + center] < s2h_tox_thres) {
				glia_state[n] = GLIA_HEALTHY; // move back to healthy
				tox_prod[center] = k_healthy_glia_tox_prod;
				simulation_mask[center] = GLIA_DISPLAY_HEALTHY; // for display
				if(timer_reset) glia_death_timer[n] = 0;
			}
			else {
				glia_death_timer[n]++;
			}
		}
		else if (glia_state[n] == GLIA_HEALTHY )
		{ 	

			if (tox[offset + center] >= h2s_tox_thres) {
				tox_prod[center] = k_stress_glia_tox_prod;
				glia_state[n] = GLIA_STRESS;
				glia_death_timer[n]++;
				simulation_mask[center] = GLIA_DISPLAY_STRESS;  // for display
			}
			else {
				if (glia_death_timer[n] > 0) glia_death_timer[n]--;
			}
		}
	}
}

