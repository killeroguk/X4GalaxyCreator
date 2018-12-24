using GalaxyCreator.Model.Json;
using GalaxyCreator.Util;

namespace GalaxyCreator.Model.EconomyEditor
{
    class ProductMemento
    {
        public Product Product { get; set; }

        public ProductMemento(Product Product)
        {
            this.Product = CloneUtil.CloneJson<Product>(Product);
        }
    }
}
