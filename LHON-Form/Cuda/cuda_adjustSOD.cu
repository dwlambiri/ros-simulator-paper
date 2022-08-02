
extern "C" __global__  void cuda_adjustSOD(int* pix_idx, int pix_idx_num, float* detox, float detoxMult)
{
	
	int idx = (blockIdx.x * gridDim.y + blockIdx.y) * blockDim.x + threadIdx.x;
	
	if (idx < pix_idx_num)
	{
		int xy = pix_idx[idx];

		detox[xy] =  1-(1-detox[xy])*detoxMult;
		
	}
}
