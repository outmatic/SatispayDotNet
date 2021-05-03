using System;
using System.Text.Json.Serialization;
using SatispayDotNet.Models;

namespace SatispayDotNet.Tests
{
    public class Samples
    {
        public const string KeyId = @"h4mt066hlj3li09qjkcfa536pl76f1ei2fk4i11llen5imjcqs9c7kjph2et16icts3jef2e6b3qqhvnl46tqjprt7ppvgp47etrcqm1i9kfnfogse8mttb8hf3dd8dgmt94hccc2cjqekv7nse1jl63q6hhc2e2r7lj5fmb2n0bv9eok68v2fmuvfr7cg07bjo03d5t";
        public const string PrivateKey = @"MIIJKQIBAAKCAgEAyLq/0HU45IjfWstBVZ9GfDl/kdFCuwvZwTk3i2Tlj8UfkcMw
                                           ux/0TaHrTlLYAGqCX/+ZGkSTxzn3ngfmsleF61QngFQUWpOHh3h6QbJ8Hy98+0qY
                                           wlE0ku3k03JgEyMHuS+pX4i8Ov9bdPaYpr6qBbdNq+TUZ6w2eFGocsXuNBJMBevT
                                           DNXRlg3oX2/KeMociaXpWPJzYDrAfJXszItytbiG22mog6cR877ILZpmt5PIB5fo
                                           hFX2F6NfhiZLPrFThgU9Q4D1CbXlahMEB3mqlaez1IhsCCbWZX0YBIJXgH8YQmk0
                                           W1Mqv524ucKbsMImDQwweM8NOYKq0cZWCxGMK2Z+HxkeHXgFa72adEG+wVMaFt/h
                                           43lyX93jY9fG76uy+EyH+Pppa7Edraefcc/iBiPpPptQP/0l+9W9G67WlJhdw33b
                                           9nYJOLv3+nAHJg+jkR8v2psXqElVkQfHeb/EtdbjNaYP8ge4qQGqiOdyw97Cow9q
                                           /B7X27m8krL3nmeI6LqVai71M7bYgXCzMZ7/88UhBc29dSN6P8eZridfbcrJRJRl
                                           9sR/NgL8R56orZzQgFbmTr5HlfXYgfih93jgtb9II1tpdLyQRWHI7yaH+pox/AAB
                                           D8ZwYqswApIWg+vaH2WVTuVZXGo1PV1ZGYFWOnetNztS8QK8NW/yK2I4FM0CAwEA
                                           AQKCAgACDVa0rN4eCAAwj29ljrFLx9K0DO2ft+lL/mfA9xEZvSwrc1FmOFdpC8S6
                                           EkK/Dley34wTJqxUFxWe+fmzzQ1DcKLOvw1ON7/k9KhbT5XRQ80FTKfvJKFi9yel
                                           ub+dsnf7vq7+mQlDmSS4N2UsHzrhwBP9M+OwA6Sy6jLMqZVb1uwMC3Mm6HCyFgZQ
                                           I3ZwcbCE/7s4+5GOZEtferDnDm3nybEnQRdF8UlPsp2dSbzPF6Wt3jG0WKShbTwm
                                           xPFz/KAb+KW9sO3QYZms0fDymp3R1dsSyyo/kxYSB4tdUG/QknwPAcBVRq5jMxuW
                                           WpT446M78unz8jnyYpGYf2yVxGIocsMkEvB1Sy6CsXxjaMIe75YYZoaq/smX3avk
                                           sqCL0T4f3BdGDnTRY685il/fMMMfGn8ydvm23MvIkGtVq9pIPC1wSA7+CbRkT6BW
                                           EEHVZL4OUHUs9xBdGCNMe1ddbMcmTXS/57aw74qFT4TyAt3o5LET/yUREaR+0HsR
                                           7Aw5aRVEw97pU7aOS2N82mt753GsQF6EXRQHs1peg1i5k6PoKyS1cVGXoWFhS7PE
                                           +Sk9WTxWgQjT0SoLn6GJz1PWskV2xySllQRv9zSmLtYGrhIQVFja0hfqVK+ASFlg
                                           vK2/OVGSsbZiKIG8Uz7TAT+JSyhJ3+KzCtWDP7YtDomLTRh0wQKCAQEA/sAnZZnK
                                           biChXBFkuGlZ+rfMpVsxA3wvoIXXUwZqAQSyg1I3NGJSLb6dbyASO9H85PPaBzA8
                                           THZdrSblNjkeNiuyUxmk759kbNrghM8D8fmraJ8uhjtzObRyHm/3a0P1Dnbiy6It
                                           eofIHDamKKXzqxkaQNA+iT20pmAJf3r4DkVLNI5c/DHcRfUMBJLM+0BJkGkZ1G3Z
                                           TrqgHzt8CSbozQ4aHNwJB1d5f184scIghKCoupeDXMIVar2CH9s21FRFLRCrnAX4
                                           srvghJO4Au0/4Kg/N6oZeztTuxvvouUKQNm/HLV0lxtTx12CHbvKYDEbHF5+kgQo
                                           S+uIXOpTLj9ixQKCAQEAybbFPBoDs53FCHozA8glvNyQS7GsjjDH1AAtj71Lq3eY
                                           PCsAihZxM6l8H4ERY8zW9LfkIW4Fyag4cfyUAvMEWGLMlUHmRg7i0k4gkdmCLq+b
                                           ZDqKXbazuSCAe1vNKkDp0TD2NecGLqPxsWQEcOJNTCB7uxf7+eBIU5jAjyHrY7QB
                                           9bily6TFgQT9e0gBtLjnUv3yPe/J6uIQGcHzUNqZOQB7dZ1vRxXm5QV+I9cSpOpm
                                           wHrKnrVYKl/9OTJ+Hf3myXUW0z/06kNu/sB7HTTw0xFQq8ippXHSn/gmBGfE6h+z
                                           2mu/OB8mEHH//zd3XazAiCy+MFr6rqEA3ItYVzdqaQKCAQEAr/5YOVzR+NsaHtz1
                                           VGGUBB3Oh75EUkANNzy/0V/xA9sW6Jp4APycAXZalVb2wdUEfbfpvGWagsiTVvg0
                                           Cg3TzWDKxZZF2DWpz3o2+gl6lEUEIjc2kQ2pQQhkfpqjt7svJVsEu+HCwY/ks3kd
                                           uZ9Mg7vH41b6nR3AG+DlLujpThKZLincG27m2n28W7x/WGTFbbruWU+6fSV5UZpq
                                           ynfTBTbk22M36ZaJHXHPXR7cEERdzOq3mfGLkj5yE0gCzRWa5NNLe3K0qeYZ6f2T
                                           dpIpOy+A3RfqmrQV2IIoP8U0HDFSUqcZcPs0GduD9L6zxVinfiXaE05D+I8zmd1Y
                                           se6gcQKCAQAEEm963h+TAa1XlXfwLJsua9lx3b1ZBX0TN4mz7CNZ68kj9c5F+1v/
                                           qf06eZWLSThRqmCtmBX/0yiIjIvEX3mH+z6cCL+ITIahrjgUGar6HEtrw47Fg4mv
                                           RAuz8c97eeH+ehmOTwKd8GtRpG4+hSMAVWuKBFru2Ws8XMoOWaXx1lFvz3FxYfsm
                                           tp4TXgnCxzTMRRody/hsiHHAw1yRFkifkPXtEueLLNMDbo/0U0QqFh1K52+tsoV8
                                           HYH0JKPNITIGgRmb3B+qlv/nnqUdmtL9v8y8GwnpsBmLZywFTL755vfvgdtTW7We
                                           AV8knM8JEhK07QpN2ZhT7CYjTaDT6ed5AoIBAQDvi33NRM8P4GYgS81Q33NTcngY
                                           QU3jWYrlo28qfQMsLBpY9GxGdgb8Cu1bUK7Ory0AlNnd2nMPdJO0hAM0pyR0PA5A
                                           dEJm01lUp9FoDNY/ILYmZeKi7bV2cXlQAxty/hYIg1b+VDMrkEcCjyJUZQE2n7gA
                                           5lEHQFuMnx6lbuZIWsWg7MDAcwgDJiF/fR9m+mnGyE4CUtviKaFzc0RrS/9yHYFI
                                           +1AY92XMskU/c82SfePJemXIy2adYFwSikxofwxvgxL4R3wjbL9AKEum1o3S500i
                                           owjQ4FujCPN1CDMQiZjOF0NV0B8YXLr92FCIpLJBorefke2Gn4Esxkv51bQp";

        public const string ExpectedEmptyBodyDigest = @"SHA-256=47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=";
        public static string ExpectedEmptyBodySignature = $@"keyId=""{KeyId}"", algorithm=""rsa-sha256"", headers=""(request-target) host date digest"", signature=""jXKERhrU/LZmGxlLN3EWxUJIGWAaZ3I3T5dUOoq5oXE3rgTCuCBfNn4SQ2losXr+x7SsKUnbMhhCTNVyrxOOgh4nAaey5gaEf9LcwiRYQlqhk7fF+VPulBBEylOqTQJe4Nn/SYqqKWopnHfHW6nAIBPtCGr6nIqbCDVRJuImRJG7stsz883fIpGL45OCsYr92ayBZ7k41NzjE7U8s24Gqu6yFPNdagUlTxyU7dWRxCz40xAyFyetU0QrKCcvVvaHIEK193RBAXZtOFWvtAAItM4MDiPSFYukrid6KtPNvttnOyERfE17+F3d/FVAXvwF+gBM+gpl31LMAO7bR5hSaIgdiL2mukifGKuB2/IWSTQW7Dx0aYZGnULKiws9odw3LbrcDkb34puJyrjkwZ1LLTwcmikj0pdL+gFI4ut74ONo8ZkrN8YeNbEsj1tVZkyuFfTQdunOpAI7SrECVu7p/VfeDxeax6/1a1/offCoow7SepZIO0CWcLc4k6ulpaIvC6fcsJL/v8jfnMIX50sYucgQVg/kaW48NVRTLoonMxXEZfDUJGP0RyabfOSia/Jlvs7i4Z0oj1nvk/vyvf+YdPcYNHsB16n+lgRdqieKd4+ogAIKkr3EIrVR4PXrHTGnUB66CgR6zB0entp1x1PeZxOGBpG7BqEiPyze/hCzKmg=""";

        public const string ExpectedDigest = @"SHA-256=ZML76UQPYzw5yDTmhySnU1S8nmqGde/jhqOG5rpfVSI=";
        public static string ExpectedSignature = $@"keyId=""{KeyId}"", algorithm=""rsa-sha256"", headers=""(request-target) host date digest"", signature=""Mp9auLbCVnAB+DhBeQwTp0Cvi3WvHNq1KHZWX7BOQ8NMz3wnOVjYyZ16vA/yz1duyDX9eZ2Y0OkQLaoFT/ioeRoUT2bHVMJOjS9dXr5xVWvL3vWMjgAmRvdQp5MCALrIb3cyOHLli+w+qYetPFVDR3PCTjbNHHnYeJkkCjp2RRx+PeT3ePTPzs1VHoOnPB0NNkj4KUGLHKq4P5bfSBk5Ci9XPnGAyjhldq+F0n9Ve0SWWcHUqT7kmX4HJPJd7HmAUkdpwLi0zQG5dvZaVYChKdH2YlztZK/oVibKGOx6SelyytDdoXXAbtGeW2kD/LDVMqQ/kKvOblcI8PiLQrn2TXPnnLtgasb/B6aJ1PRbeuv3TvW6AWteVfbySfc7C0iRd6vw3Voz6DMAGqcI6Jjb0xJCODkQF90O50IKV/1N4jBb48+cc8g4Ae/YFgGJGmHI0DiDGPQamXEho3UgZJTrghRRQ/y6AXyY0pGasOG+xvP+nZmIxWxyTaXG/mU6ytWfM8I2EAGP3/rQ4nrktdkylyprmnNMXHsppd46BK8oyihaGAKtA6U7wlZ0lojoaDt24vvlw5dn8sJy2CCOwvhRBeuC4Qir+3TJ4aJgzIqD+S/MFH6qo6BFUN5pC6mbncyCpHwiu10OVkSTeJM1UzXQ1llPWlXVhqEcwQal+bTIGw8=""";

        public class SampleRequest
        {
            [JsonPropertyName("flow")]
            public string Flow { get; set; }
            [JsonPropertyName("amount_unit")]
            public int AmountUnit { get; set; }
            [JsonPropertyName("currency")]
            public string Currency { get; set; }
        }

        public class SampleOrder
        {
            public string Id => $"ORD_{DateTime.Now.Ticks}";
            public int Amount => 100;
            public Currency Currency => Currency.EUR;           
        }
    }
}