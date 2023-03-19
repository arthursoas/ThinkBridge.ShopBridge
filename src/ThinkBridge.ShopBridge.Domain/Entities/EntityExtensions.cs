namespace ThinkBridge.ShopBridge.Domain.Entities
{
    public static class EntityExtensions
    {
        public static void MergeEntity<T>(this T target, T source)
            where T : EntityBase
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                if (prop.Name == nameof(EntityBase.Id) ||
                    prop.Name == nameof(EntityBase.CreateDate) ||
                    prop.Name == nameof(EntityBase.UpdateDate))
                {
                    continue;
                }

                var defualtValue = prop.PropertyType.IsValueType ?
                    Activator.CreateInstance(prop.PropertyType) :
                    null;

                var value = prop.GetValue(source, null);
                if (value == null || value.Equals(defualtValue))
                {
                    continue;
                }

                prop.SetValue(target, value, null);
            }
        }
    }
}
