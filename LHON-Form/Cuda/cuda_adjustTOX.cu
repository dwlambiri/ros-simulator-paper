
extern "C" __global__  void cuda_adjustTOX(int* pix_idx, int pix_idx_num, float* tox, float toxMult)
{
	
	int idx = (blockIdx.x * gridDim.y + blockIdx.y) * blockDim.x + threadIdx.x;
	
	if (idx < pix_idx_num)
	{
		int xy = pix_idx[idx];

		tox[xy] =  tox[xy]*toxMult;
		
	}
}
