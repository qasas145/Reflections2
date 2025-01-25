
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using Reflections2;

public class Program
{
    public static void Main(string[] args)
    {
        var type = Assembly.Load(nameof(Startup));

        #region old method 
        //var classType = type.GetType("Startup.Math");
        //var method = classType.GetMethod("SayHello");

        //var classInstance = InstanceCreation.CreateInstance(classType);

        //var resultOfMethodInvoked = method.Invoke(classInstance, new object[] { "Elqasas Sayed Osmna" });

        //Console.WriteLine("The result is {0}", resultOfMethodInvoked);
        #endregion


        #region new method
        // ================ second method of doing this thing ================
        dynamic obj = new ExposedObject(type.GetType(nameof(Startup)+".Startup"));

        //var result = obj.StartupMethod();
        //Console.Write("The result is ");
        //Console.ForegroundColor = ConsoleColor.Green;
        //Console.WriteLine("{0}", result);
        //Console.ForegroundColor = ConsoleColor.White;

        // ====================== part related to the dynanic objects  =============================
        //var name = obj.name;
        //Console.WriteLine(name);

        // ============== new part related to extension method ===============
        var exposedObj = type.GetType(nameof(Startup) + ".Startup").Exposed();
        //var name = exposedObj.name;
        //Console.WriteLine("the name of the new method is {0}",name);


        #endregion




    }
}