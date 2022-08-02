
#define rateUpLayerIndex  4
#define rateDownLayerIndex  5
#define rate_values_size 13

/*
private readonly int voxelNoProd_c = -1;
        private readonly int tissueProd_c = 0;
        private readonly int voxelGliaMito_c = 1;
        private readonly int voxelGliaProd_c = 2;
        private readonly int voxelMembrane_c= 3;
        private readonly int voxelRgcMito_c = 4;
        private readonly int voxelRgcProd_c = 5;
*/

#define voxelRgcMito_c  4
#define voxelRgcProd_c  5

extern "C" __global__  void cuda_diffusion3DBottom(int* pix_idx, int pix_idx_num, unsigned short im_size,
	float* tox, float* detox, float* tox_prod, unsigned char* rate, float* rate_values_array, int layerNo,
	int dstl, int tl, int ml, int bl, float mult, float detoxmult, int* assignedPixelMap)
{
	int idx = (blockIdx.x * gridDim.y + blockIdx.y) * blockDim.x + threadIdx.x;
	if (idx < pix_idx_num)
	{
		int xy = pix_idx[idx];

		//int sq = im_size * im_size;

		int xy0 = xy + im_size;
		int xy1 = xy - im_size;
		int xy2 = xy + 1;
		int xy3 = xy - 1;
		
		// [DWL] in the 3D sim there are 6 neighbours
		int xyN = xy * 6;

		float* tox_new = &tox[dstl];
	    float* tox_old = &tox[ml];
		float* tox_up = &tox[tl];
		//float* tox_down = &tox[bl];
		float* rate_values = &rate_values_array[rate_values_size * layerNo];

		float t = tox_old[xy];

		//tox_new[xy] = t +
		float cnew = t + 
			(tox_old[xy0] - t) * rate_values[rate[xyN]] +
			(tox_old[xy1] - t) * rate_values[rate[xyN + 1]] +
			(tox_old[xy2] - t) * rate_values[rate[xyN + 2]] +
			(tox_old[xy3] - t) * rate_values[rate[xyN + 3]] + 
			(tox_up[xy] - t) * rate_values[rate[xyN + rateUpLayerIndex]];

		//[DWL], below is written the way it is because we must multiply the 'K'
		//of othe scavenging differential rate equation by detoxmult
		//Since the K (by the time it is used in this file) is already passed as a value of 1-K 
		//We must convert it back to K, mulitply by detoxmult, then convert back to 1-k

		//tox_new[xy] = cnew * (1 - (1 - detox[xy]) * detoxmult) + (tox_prod[xy] >= 0 ? tox_prod[xy] : 0) * mult;
		tox_new[xy] = cnew * (1 - (1 - detox[xy]) * detoxmult) + (tox_prod[xy] >= 0 ? tox_prod[xy] : 0) * ((assignedPixelMap[xy] < 0)? 1: mult);
		//float dex = detox[xy] * t * detoxmult;
		//tox_new[xy] = (cnew < dex ? 0 : cnew - dex);
		
	}
}
