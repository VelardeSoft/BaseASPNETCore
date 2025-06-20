using System.Text.RegularExpressions;

namespace BaseASPNETCore.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static partial class StringExtensions
{
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text; 
        }

        return KebabCaseRegex().Replace(text, "-$1")
            .Trim()
            .ToLower(); 
    }
    [GeneratedRegex("(?<!^)([A-Z]|[a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    
    private static partial Regex KebabCaseRegex();
}

/*
Esta clase implementa una extensión para el tipo string que permite convertir 
cadenas de texto a formato kebab-case (palabras separadas por guiones y en minúsculas). 
Por ejemplo, "MiTextoDePrueba" se convierte en "mi-texto-de-prueba". Utiliza una 
expresión regular compilada para identificar los lugares donde debe insertar los guiones. 
Es útil para generar rutas, nombres de archivos o identificadores que sigan la convención 
kebab-case.
 */