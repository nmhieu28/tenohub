using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using HNM.Core.Domain.Entities;
using HNM.Core.Helpers;

namespace HNM.Core.Domain.Entities;

public static class EntityHelper
{
    public static bool EntityEquals(IEntity? eFirst, IEntity? eSecond)
    {
        if (eFirst == null || eSecond == null)
        {
            return false;
        }

        if (ReferenceEquals(eFirst, eSecond))
        {
            return true;
        }

        var typeOfeFirst = eFirst.GetType();
        var typeOfeSecond = eSecond.GetType();
        if (!typeOfeFirst.IsAssignableFrom(typeOfeSecond) && !typeOfeSecond.IsAssignableFrom(typeOfeFirst))
        {
            return false;
        }

        if (HasDefaultKeys(eFirst) && HasDefaultKeys(eSecond))
        {
            return false;
        }

        var eFirstKeys = eFirst.GetKeys();
        var eSecondKeys = eSecond.GetKeys();
        if (eFirstKeys.Length != eSecondKeys.Length)
            return false;
        for (var i = 0; i < eFirstKeys.Length; i++)
        {
            var entityKeyFirst = eFirstKeys[i];
            var entityKeySecond = eSecondKeys[i];

            if (entityKeyFirst == null)
            {
                if (entityKeySecond == null)
                {
                    continue;
                }

                return false;
            }

            if (entityKeySecond == null)
            {
                return false;
            }

            if (TypeHelper.IsDefaultValue(entityKeyFirst) && TypeHelper.IsDefaultValue(entityKeySecond))
            {
                return false;
            }

            if (!entityKeyFirst.Equals(entityKeySecond))
            {
                return false;
            }
        }

        return true;
    }

    private static bool HasDefaultKeys([NotNull] IEntity entity)
    {
        Check.NotNull(entity, nameof(entity));
        return entity.GetKeys().All(IsDefaultKeyValue);
    }

    private static bool IsDefaultKeyValue(object? value)
    {
        if (value == null)
        {
            return true;
        }

        var type = value.GetType();

        if (type == typeof(int))
        {
            return Convert.ToInt32(value) <= 0;
        }

        if (type == typeof(long))
        {
            return Convert.ToInt64(value) <= 0;
        }
        return TypeHelper.IsDefaultValue(value);
    }
}