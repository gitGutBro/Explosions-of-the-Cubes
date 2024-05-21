public static class Math
{
    public static float GetInverseProportionalityValue(float upperBound, float minOutputValue, float inputData) =>
        upperBound * (minOutputValue / inputData);
}