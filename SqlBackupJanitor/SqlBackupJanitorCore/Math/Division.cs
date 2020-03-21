using System;
namespace SqlBackupJanitorCore.Math
{
  public class Division
  {
    public float Divide(int upper, int lower)
    {
      if (lower == 0)
      {
        throw new Exception("Cannot divide by zero.");
      }
      return upper / (float)lower;
    }
  }
}