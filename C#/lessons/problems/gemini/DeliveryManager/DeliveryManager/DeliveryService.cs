namespace DeliveryManager
{
    public class DeliveryService
    {
        private readonly decimal _baseShippingCost = 200m;
        private readonly double _weightThreshold = 10.0;
        private readonly double _distanceThreshold = 100.0;
        private readonly decimal _fragileItemMultiplier = 2m;
        private readonly Product _product;

        public DeliveryService(Product product)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
        }

        public decimal CalculateShippingCost()
        {
            if (_product == null) throw new ArgumentNullException(nameof(_product));
            if (_product.Weight > 20 && _product.IsFragile) throw new NotSupportedException(nameof(_product));

            decimal shippingCost = _baseShippingCost;

            if (_product.Weight > _weightThreshold) shippingCost += 500m;
            if (_product.Distance > _distanceThreshold) shippingCost += 300m;
            if (_product.IsFragile) shippingCost *= _fragileItemMultiplier;

            return shippingCost;
        }
    }
}
