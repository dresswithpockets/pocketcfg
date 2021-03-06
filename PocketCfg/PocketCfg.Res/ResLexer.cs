//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Res.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class ResLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		LBRACKET=1, RBRACKET=2, LBRACE=3, RBRACE=4, EXCL=5, COMMENT=6, DIRECTIVE=7, 
		FLAG=8, STRING_LITERAL=9, IDENT=10, NEWLINE=11, WS=12;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"Identifier", "LineEnder", "LBRACKET", "RBRACKET", "LBRACE", "RBRACE", 
		"EXCL", "COMMENT", "DIRECTIVE", "FLAG", "STRING_LITERAL", "IDENT", "NEWLINE", 
		"WS"
	};


	public ResLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public ResLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'['", "']'", "'{'", "'}'", "'!'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "LBRACKET", "RBRACKET", "LBRACE", "RBRACE", "EXCL", "COMMENT", "DIRECTIVE", 
		"FLAG", "STRING_LITERAL", "IDENT", "NEWLINE", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Res.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static ResLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\xE', '\x66', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x3', '\x2', '\x6', '\x2', '!', 
		'\n', '\x2', '\r', '\x2', '\xE', '\x2', '\"', '\x3', '\x3', '\x6', '\x3', 
		'&', '\n', '\x3', '\r', '\x3', '\xE', '\x3', '\'', '\x3', '\x3', '\x5', 
		'\x3', '+', '\n', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', 
		'\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\a', 
		'\t', ';', '\n', '\t', '\f', '\t', '\xE', '\t', '>', '\v', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', 
		'\a', '\n', '\x46', '\n', '\n', '\f', '\n', '\xE', '\n', 'I', '\v', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', 
		'\f', '\x3', '\f', '\a', '\f', 'R', '\n', '\f', '\f', '\f', '\xE', '\f', 
		'U', '\v', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x6', '\xE', '\\', '\n', '\xE', '\r', '\xE', '\xE', '\xE', ']', 
		'\x3', '\xF', '\x6', '\xF', '\x61', '\n', '\xF', '\r', '\xF', '\xE', '\xF', 
		'\x62', '\x3', '\xF', '\x3', '\xF', '\x5', '<', 'G', 'S', '\x2', '\x10', 
		'\x3', '\x2', '\x5', '\x2', '\a', '\x3', '\t', '\x4', '\v', '\x5', '\r', 
		'\x6', '\xF', '\a', '\x11', '\b', '\x13', '\t', '\x15', '\n', '\x17', 
		'\v', '\x19', '\f', '\x1B', '\r', '\x1D', '\xE', '\x3', '\x2', '\x5', 
		'\a', '\x2', '/', '/', '\x32', ';', '\x43', '\\', '\x61', '\x61', '\x63', 
		'|', '\x4', '\x2', '\f', '\f', '\xF', '\xF', '\x4', '\x2', '\v', '\v', 
		'\"', '\"', '\x2', 'k', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', 
		'\x2', '\x2', '\x2', '\x3', ' ', '\x3', '\x2', '\x2', '\x2', '\x5', '*', 
		'\x3', '\x2', '\x2', '\x2', '\a', ',', '\x3', '\x2', '\x2', '\x2', '\t', 
		'.', '\x3', '\x2', '\x2', '\x2', '\v', '\x30', '\x3', '\x2', '\x2', '\x2', 
		'\r', '\x32', '\x3', '\x2', '\x2', '\x2', '\xF', '\x34', '\x3', '\x2', 
		'\x2', '\x2', '\x11', '\x36', '\x3', '\x2', '\x2', '\x2', '\x13', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\x15', 'L', '\x3', '\x2', '\x2', '\x2', '\x17', 
		'O', '\x3', '\x2', '\x2', '\x2', '\x19', 'X', '\x3', '\x2', '\x2', '\x2', 
		'\x1B', '[', '\x3', '\x2', '\x2', '\x2', '\x1D', '`', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', '!', '\t', '\x2', '\x2', '\x2', ' ', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '!', '\"', '\x3', '\x2', '\x2', '\x2', '\"', ' ', '\x3', 
		'\x2', '\x2', '\x2', '\"', '#', '\x3', '\x2', '\x2', '\x2', '#', '\x4', 
		'\x3', '\x2', '\x2', '\x2', '$', '&', '\t', '\x3', '\x2', '\x2', '%', 
		'$', '\x3', '\x2', '\x2', '\x2', '&', '\'', '\x3', '\x2', '\x2', '\x2', 
		'\'', '%', '\x3', '\x2', '\x2', '\x2', '\'', '(', '\x3', '\x2', '\x2', 
		'\x2', '(', '+', '\x3', '\x2', '\x2', '\x2', ')', '+', '\a', '\x2', '\x2', 
		'\x3', '*', '%', '\x3', '\x2', '\x2', '\x2', '*', ')', '\x3', '\x2', '\x2', 
		'\x2', '+', '\x6', '\x3', '\x2', '\x2', '\x2', ',', '-', '\a', ']', '\x2', 
		'\x2', '-', '\b', '\x3', '\x2', '\x2', '\x2', '.', '/', '\a', '_', '\x2', 
		'\x2', '/', '\n', '\x3', '\x2', '\x2', '\x2', '\x30', '\x31', '\a', '}', 
		'\x2', '\x2', '\x31', '\f', '\x3', '\x2', '\x2', '\x2', '\x32', '\x33', 
		'\a', '\x7F', '\x2', '\x2', '\x33', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'\x34', '\x35', '\a', '#', '\x2', '\x2', '\x35', '\x10', '\x3', '\x2', 
		'\x2', '\x2', '\x36', '\x37', '\a', '\x31', '\x2', '\x2', '\x37', '\x38', 
		'\a', '\x31', '\x2', '\x2', '\x38', '<', '\x3', '\x2', '\x2', '\x2', '\x39', 
		';', '\v', '\x2', '\x2', '\x2', ':', '\x39', '\x3', '\x2', '\x2', '\x2', 
		';', '>', '\x3', '\x2', '\x2', '\x2', '<', '=', '\x3', '\x2', '\x2', '\x2', 
		'<', ':', '\x3', '\x2', '\x2', '\x2', '=', '?', '\x3', '\x2', '\x2', '\x2', 
		'>', '<', '\x3', '\x2', '\x2', '\x2', '?', '@', '\x5', '\x5', '\x3', '\x2', 
		'@', '\x41', '\x3', '\x2', '\x2', '\x2', '\x41', '\x42', '\b', '\t', '\x2', 
		'\x2', '\x42', '\x12', '\x3', '\x2', '\x2', '\x2', '\x43', 'G', '\a', 
		'%', '\x2', '\x2', '\x44', '\x46', '\v', '\x2', '\x2', '\x2', '\x45', 
		'\x44', '\x3', '\x2', '\x2', '\x2', '\x46', 'I', '\x3', '\x2', '\x2', 
		'\x2', 'G', 'H', '\x3', '\x2', '\x2', '\x2', 'G', '\x45', '\x3', '\x2', 
		'\x2', '\x2', 'H', 'J', '\x3', '\x2', '\x2', '\x2', 'I', 'G', '\x3', '\x2', 
		'\x2', '\x2', 'J', 'K', '\x5', '\x5', '\x3', '\x2', 'K', '\x14', '\x3', 
		'\x2', '\x2', '\x2', 'L', 'M', '\a', '&', '\x2', '\x2', 'M', 'N', '\x5', 
		'\x3', '\x2', '\x2', 'N', '\x16', '\x3', '\x2', '\x2', '\x2', 'O', 'S', 
		'\a', '$', '\x2', '\x2', 'P', 'R', '\v', '\x2', '\x2', '\x2', 'Q', 'P', 
		'\x3', '\x2', '\x2', '\x2', 'R', 'U', '\x3', '\x2', '\x2', '\x2', 'S', 
		'T', '\x3', '\x2', '\x2', '\x2', 'S', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'T', 'V', '\x3', '\x2', '\x2', '\x2', 'U', 'S', '\x3', '\x2', '\x2', '\x2', 
		'V', 'W', '\a', '$', '\x2', '\x2', 'W', '\x18', '\x3', '\x2', '\x2', '\x2', 
		'X', 'Y', '\x5', '\x3', '\x2', '\x2', 'Y', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', 'Z', '\\', '\t', '\x3', '\x2', '\x2', '[', 'Z', '\x3', '\x2', '\x2', 
		'\x2', '\\', ']', '\x3', '\x2', '\x2', '\x2', ']', '[', '\x3', '\x2', 
		'\x2', '\x2', ']', '^', '\x3', '\x2', '\x2', '\x2', '^', '\x1C', '\x3', 
		'\x2', '\x2', '\x2', '_', '\x61', '\t', '\x4', '\x2', '\x2', '`', '_', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x62', '\x3', '\x2', '\x2', '\x2', 
		'\x62', '`', '\x3', '\x2', '\x2', '\x2', '\x62', '\x63', '\x3', '\x2', 
		'\x2', '\x2', '\x63', '\x64', '\x3', '\x2', '\x2', '\x2', '\x64', '\x65', 
		'\b', '\xF', '\x2', '\x2', '\x65', '\x1E', '\x3', '\x2', '\x2', '\x2', 
		'\v', '\x2', '\"', '\'', '*', '<', 'G', 'S', ']', '\x62', '\x3', '\b', 
		'\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
