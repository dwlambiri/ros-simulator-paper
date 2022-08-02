
extern "C" __global__  void cuda_diffusion2D(int* pix_idx, int pix_idx_num, unsigned int im_size, int index_old,
	int index_new, float* tox, float* detox, float* tox_prod, unsigned char* rate, float* rate_values)
{
	
	int idx = (blockIdx.x * gridDim.y + blockIdx.y) * blockDim.x + threadIdx.x;
	
	if (idx < pix_idx_num)
	{
		int xy = pix_idx[idx];

		int xy0 = xy + im_size;
		int xy1 = xy - im_size;
		int xy2 = xy + 1;
		int xy3 = xy - 1;

		//int xyN = xy * rate_dimensions;
		//[DWL] 2D sim has 4 neigbours. mult by 4 same as shift to left by 2
		int xyN = xy << 2;
			
	    float* tox_old = &tox[index_old];
		float* tox_new = &tox[index_new];
		
		int rn = rate[xyN];
		int rn1 = rate[xyN + 1];
		int rn2 = rate[xyN + 2];
		int rn3 = rate[xyN + 3];

		float t = tox_old[xy];

		float cnew = t +
			(tox_old[xy0] - t) * rate_values[rn] +
			(tox_old[xy1] - t) * rate_values[rn1] +
			(tox_old[xy2] - t) * rate_values[rn2] +
			(tox_old[xy3] - t) * rate_values[rn3];

		tox_new[xy] = cnew * detox[xy] + (tox_prod[xy]>=0? tox_prod[xy]:0);

		//float dex = detox[xy] * t;
		//tox_new[xy] = ((cnew < dex) ? 0 : cnew - dex);
	}
}
