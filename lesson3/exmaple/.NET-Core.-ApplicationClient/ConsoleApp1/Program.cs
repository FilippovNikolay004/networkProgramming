using System.Reflection;

Assembly assembly = Assembly.LoadFrom("Init Print.dll");
Type[] types = assembly.GetTypes();

//foreach (Type type in types) {
//    Console.WriteLine(type.FullName);
//}

//object myObj = Activator.CreateInstance(types[0]);
//types[0].GetMethod("Print").Invoke(myObj, null);

string typename = types[0].FullName;
assembly.GetType(typename);

Type type = assembly.GetType(typename);
object myobj = Activator.CreateInstance(type);

type.GetMethod("Print").Invoke(myobj, null);

MethodInfo met = type.GetMethod("Sum");
met.Invoke(null, [10, 20]);