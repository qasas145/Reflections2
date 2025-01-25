using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections2
{
    public class ExposedObject : DynamicObject
    {
        private readonly Type _type;
        public ExposedObject(Type type)
        {
            _type = type;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            var name = binder.Name;
            var getMethod = _type.GetField(binder.Name);
            if (getMethod == null)
                return base.TryGetMember(binder, out result);
            var instance = InstanceCreation.CreateInstance(_type);
            var fieldValue = getMethod.GetValue(instance);
            result = fieldValue;
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            var methodName = binder.Name;
            var method = _type.GetMethod(methodName);
            if ( method == null)
            {
                return base.TryInvokeMember(binder, args, out result);
            }
            var instance = InstanceCreation.CreateInstance(_type);
            var methodResult = method.Invoke(instance, new object[] {});

            result = methodResult;
            return true;
        }
    }
}
