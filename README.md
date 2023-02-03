# CSharpPersudoRandom
Persudo random for C#，main difference from System.Random is that we can get value for given index


Use it like System.Random:
```csharp
int seed = 10;
var random = new CustomIndexRandom(seed);
random.Next();
```

Get by index:
```csharp
random.NextByIndex(1024)
```

noise picture:

![](./noise.jpg)


# Additional

If you can not change every usage in old project, you can aslo use reflection to save/apply the state of `System.Random`.
```csharp
var rand = new Random(8798);
for (int i = 0; i < 1024; i++) rand.NextDouble();

// reflection
var inextfieldInfo = typeof(System.Random).GetField("inext", BindingFlags.Instance | BindingFlags.NonPublic);
var inextpFieldInfo = typeof(System.Random).GetField("inextp", BindingFlags.Instance | BindingFlags.NonPublic);
var SeedArrayFieldInfo = typeof(System.Random).GetField("SeedArray", BindingFlags.Instance | BindingFlags.NonPublic);

// save random state
int inext = (int)inextfieldInfo.GetValue(rand);
int inextp = (int)inextpFieldInfo.GetValue(rand);
int[] seedArray = (int[])SeedArrayFieldInfo.GetValue(rand);
int[] newSeedArray = new int[seedArray.Length];
for (int i = 0; i < seedArray.Length; i++)
{
    newSeedArray[i] = seedArray[i];
}

var f = rand.NextDouble();
Console.WriteLine("pre random value:" + f);

// set random state
var newRand = new Random(8798);
inextfieldInfo.SetValue(newRand, inext);
inextpFieldInfo.SetValue(newRand, inextp);
SeedArrayFieldInfo.SetValue(newRand, newSeedArray);

f = newRand.NextDouble();
Console.WriteLine("cur random value:" + f);
```
the out put is
```
pre random value:0.279870075304001
cur random value:0.279870075304001
```
