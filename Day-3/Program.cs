int num = 7, flag = 1;
for (int i = 2; i < num; i++)
{
if (num % i == 0)
{
flag = 0;
break;
}
}
Console.Write(flag == 1 ? "Prime" : "Not Prime");
