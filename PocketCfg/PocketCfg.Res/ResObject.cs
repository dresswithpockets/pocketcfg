using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PocketCfg.Res
{
    public class ResUnit
    {
        // IEnumerable<string> Directives, IEnumerable<ResObject> Objects

        public IEnumerable<string> Directives { get; }
        public IEnumerable<ResObject> Objects { get; }

        public ResUnit(IEnumerable<string> directives, IEnumerable<ResObject> objects)
        {
            Directives = directives;
            Objects = objects;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var dir in Directives) sb.AppendLine(dir);
            foreach (var obj in Objects) sb.AppendLine(obj.ToString());
            return sb.ToString();
        }
    }
    
    public class ResObject
    {
        public string Name { get; set; }
        public List<ResObject> Properties { get; } = new List<ResObject>();
        public string? Value { get; set; }

        public Dictionary<string, bool> Flags { get; } = new Dictionary<string, bool>();

        public bool X360Only => Flags.TryGetValue("X360", out var val) && val;
        public bool Win32Only => Flags.TryGetValue("WIN32", out var val) && val;
        public bool OsxOnly => Flags.TryGetValue("OSX", out var val) && val;
        public bool LinuxOnly => Flags.TryGetValue("LINUX", out var val) && val;

        public bool NotX360 => Flags.TryGetValue("X360", out var val) && !val;
        public bool NotWin32 => Flags.TryGetValue("WIN32", out var val) && !val;
        public bool NotOsx => Flags.TryGetValue("OSX", out var val) && !val;
        public bool NotLinux => Flags.TryGetValue("LINUX", out var val) && !val;

        public bool X360 => !Flags.ContainsKey("X360") || X360Only || ((NotWin32 || NotOsx || NotLinux) && !NotX360);
        public bool Win32 => !Flags.ContainsKey("WIN32") || Win32Only || ((NotLinux || NotOsx || NotX360) && !NotWin32);
        public bool Osx => !Flags.ContainsKey("OSX") || OsxOnly || ((NotWin32 || NotLinux || NotX360) && !NotOsx);
        public bool Linux => !Flags.ContainsKey("LINUX") || LinuxOnly || ((NotWin32 || NotOsx || NotX360) && !NotLinux);

        public bool IsValue => Value != null;
        public bool IsObject => !IsValue;
        
        public ResObject(string name) => Name = name;

        public int? GetInt() => int.TryParse(Value, out var val) ? val : (int?) null;
        public float? GetFloat() => float.TryParse(Value, out var val) ? val : (float?) null;
        public bool? GetBool() => bool.TryParse(Value, out var val) ? val : (bool?)null;
        public ResColor? GetColor() => Value == null ? null : ResColor.FromString(Value);
        public string? GetString() => Value;

        public override string ToString() => ToString(0);

        public string ToString(int level)
        {
            var sb = new StringBuilder();
            sb.Append($@"""{Name}""".PadLeft(level * 4, ' '));
            if (IsValue) sb.Append($@"""{Value}""");
            foreach (var flag in Flags)
                sb.Append($" [{(flag.Value ? "!" : string.Empty)}${flag.Key}]");
            sb.AppendLine();
            if (IsObject)
            {
                sb.AppendLine("{".PadLeft(level * 4, ' '));
                foreach (var property in Properties)
                    sb.Append(property.ToString(level + 1));
                sb.AppendLine("}".PadLeft(level * 4, ' '));
            }

            return sb.ToString();
        }
    }

    public struct ResColor
    {
        public byte R, G, B, A;

        public ResColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static ResColor? FromString(string input)
        {
            var values = input.Split(' ').Select(i => byte.TryParse(i, out var val) ? val : (byte?)null).ToList();
            if (values.Contains(null)) return null;
            var noNull = values.Select(v => v.Value).ToList();
            return new ResColor(noNull[0], noNull[1], noNull[2], noNull[3]);
        }
    }
}