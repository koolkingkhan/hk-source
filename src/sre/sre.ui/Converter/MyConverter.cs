using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace sre.ui.Converter
{
    public class MyConverter : IValueConverter
    {
        public SolidColorBrush DefaultValue { get; set; }

        private readonly Dictionary<string, Func<string, Result>> _validation;

        private bool _initialized;

        private enum Error
        {
            Message,
            Foreground,
            Background,
            LblBackground
        };

        public MyConverter()
        {
            if (_validation == null)
            {
                _validation = new Dictionary<string, Func<string, Result>>
                    {
                        {"name", Rules.IsNonNumericString},
                        {"id", Rules.IsValidNumber},
                        {"age", Rules.IsValidNumber},
                        {"salary", Rules.InRange},
                    };
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string param = parameter as string;
            if (string.IsNullOrEmpty(param))
            {
                return Brushes.Black;
            }

            Error returnValType = Error.Message;

            string[] tokens = param.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length > 1)
            {
                Error errorType;
                if (Enum.TryParse(tokens[1], true, out errorType))
                {
                    returnValType = errorType;
                    param = tokens[0];
                }
            }

            Func<string, Result> action;
            if (_validation.TryGetValue(param.ToLowerInvariant(), out action))
            {
                string str = value as string;

                if (string.IsNullOrEmpty(str) && !_initialized)
                {
                    switch (returnValType)
                    {
                        case Error.Message:
                            return string.Empty;
                        case Error.Foreground:
                            return Brushes.Black;
                        case Error.Background:
                            return Brushes.Black;
                        case Error.LblBackground:
                            return Brushes.Transparent;
                    }
                }
                else
                {
                    _initialized = true;
                }

                var result = action(str);

                if (!_initialized && string.IsNullOrEmpty(value as string))
                {
                    return null;
                }

                switch (returnValType)
                {
                    case Error.Message:
                        return result.Valid ? string.Empty : result.ErrorMessage;
                    case Error.Foreground:
                        return result.Valid ? Brushes.Black : Brushes.White;
                    case Error.Background:
                        return result.Valid ? Brushes.Black : Brushes.Red;
                    case Error.LblBackground:
                        return result.Valid ? Brushes.Transparent : Brushes.Red;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
