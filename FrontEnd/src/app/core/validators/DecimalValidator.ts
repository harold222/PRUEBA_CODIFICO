import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function DecimalValidator(maxInteger: number, maxDecimal: number): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) return null;

    // Expresión regular: hasta 3 dígitos antes del punto, opcionalmente decimales
    const regex = new RegExp(`^\\d{1,${maxInteger}}(\\.\\d{1,${maxDecimal}})?$`);

    if (!regex.test(value))
      return {
        decimal: {
          valid: false,
          message: `Debe tener máximo ${maxInteger} dígitos antes del punto decimal y ${maxDecimal} dígitos decimales.`,
        },
      };

    return null; // Es válido
  };
}