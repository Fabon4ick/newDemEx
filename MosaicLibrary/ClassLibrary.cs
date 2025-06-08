using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using newDemEx.BaseModel;

namespace MosaicLibrary
{
    public class ClassLibrary
    {
        private sdvgEntities _db = new sdvgEntities().GetContext();

        public int CalculateMaterial
            (
                int productTypeId,
                int materialTypeId,
                int productAmount,
                int stockAmount,
                double param1,
                double param2
            )
        {
            var productType = _db.ProductType.Where(p => p.Id == productTypeId).FirstOrDefault();
            var materialType = _db.MaterialType.Where(m => m.Id == materialTypeId).FirstOrDefault();

            if (productType == null ||
                materialType == null ||
                productAmount <= 0 ||
                stockAmount < 0 ||
                param1 <= 0 ||
                param2 <= 0)
                return -1;

            int produceProduct = productAmount - stockAmount;

            if (produceProduct <= 0)
            {
                return 0;
            }

            var materialPerUnit = param1 * param2 * (double)productType.TypeCoefficient;

            double materialAmount = (double)materialPerUnit * produceProduct;

            double totalMaterial = materialAmount * (double)(1 + materialType.MaterialDeffect);

            return (int)Math.Ceiling(totalMaterial);
        }
    }
}
