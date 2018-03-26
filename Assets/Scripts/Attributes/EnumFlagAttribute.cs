using UnityEngine;

namespace Attributes {
    public class EnumFlagAttribute : PropertyAttribute {
        public int columnCount;

        public EnumFlagAttribute(int columnCount) {
            this.columnCount = columnCount;
        }
    }
}