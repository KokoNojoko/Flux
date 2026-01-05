namespace SharedKernal
{
    public sealed record Error(string code, string Desription)
    {
      public static readonly Error None = new Error(string.Empty, string.Empty);

      public static implicit operator SharedKernal.Result(Error error) => Result.Failure(error);
    }
}
