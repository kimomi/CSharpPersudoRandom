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
