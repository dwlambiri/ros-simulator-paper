
extern "C" __global__  void cuda_tox_sum(int* pix_idx, int pix_idx_num, float* tox, float* tox_sum, int* regionalMask, float* zone_tox_sum, int offset, int imsquare, int no3dLayers)
{
	int idx = (blockIdx.x * gridDim.y + blockIdx.y) * blockDim.x + threadIdx.x;
	if (idx < pix_idx_num)
	{
		int xy = pix_idx[idx];
		if (no3dLayers>1) {
			float sum = 0;
			for (int i = 0; i < no3dLayers; i++) {
				sum += tox[((offset + i) % (no3dLayers + 2))*imsquare + xy];
			}
			atomicAdd(tox_sum, sum);
			if(regionalMask[xy] >= 0){
			    atomicAdd(&zone_tox_sum[regionalMask[xy]], sum);
			}
		}
		else {
			atomicAdd(tox_sum, tox[offset*imsquare + xy]);
			if(regionalMask[xy] >= 0){
				atomicAdd(&zone_tox_sum[regionalMask[xy]], (float) tox[offset*imsquare + xy]);
			}
		}
		
	}
}
