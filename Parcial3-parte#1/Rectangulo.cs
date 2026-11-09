public class Rectangulo : Figura
{
    private double baseR;
    private double altura;

    public Rectangulo(double baseR, double altura)
    {
        this.baseR = baseR;
        this.altura = altura;
    }

    public override double CalcularArea() => baseR * altura;
    public override double CalcularPerimetro() => 2 * (baseR + altura);
}