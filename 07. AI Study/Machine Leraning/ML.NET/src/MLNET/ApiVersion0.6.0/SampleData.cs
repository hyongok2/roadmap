using Microsoft.ML.Runtime.Api;

namespace ApiVersion0._6._0
{
    internal class SampleData
    {
        [Column("0")]
        public float INPUT1;
        [Column("1", name:"Label")]
        public float OUTPUT;
    }
}
