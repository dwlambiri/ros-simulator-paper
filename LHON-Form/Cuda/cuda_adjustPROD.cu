

extern "C" __global__  void cuda_adjustPROD(int n_axons, float* hProd, float* sProd, float toxMult)
{
	int n = threadIdx.x + blockIdx.x * blockDim.x;

	if (n < n_axons)
	{
		hProd[n] = hProd[n]*toxMult;
		sProd[n] = sProd[n]*toxMult;
	}
}

