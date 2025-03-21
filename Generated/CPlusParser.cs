//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CPlus.g4 by ANTLR 4.13.1

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
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class CPlusParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, CLASS=8, PUBLIC=9, 
		PRIVATE=10, ID=11, WS=12;
	public const int
		RULE_program = 0, RULE_class_decl = 1, RULE_method_decl = 2, RULE_type = 3, 
		RULE_numeric_type = 4, RULE_string_type = 5, RULE_bool_type = 6, RULE_void_type = 7;
	public static readonly string[] ruleNames = {
		"program", "class_decl", "method_decl", "type", "numeric_type", "string_type", 
		"bool_type", "void_type"
	};

	private static readonly string[] _LiteralNames = {
		null, "'{'", "'}'", "'float'", "'int'", "'string'", "'bool'", "'void'", 
		"'class'", "'public'", "'private'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, "CLASS", "PUBLIC", "PRIVATE", 
		"ID", "WS"
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

	public override string GrammarFileName { get { return "CPlus.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static CPlusParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public CPlusParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public CPlusParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgramContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(CPlusParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Class_declContext[] class_decl() {
			return GetRuleContexts<Class_declContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public Class_declContext class_decl(int i) {
			return GetRuleContext<Class_declContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(Context, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 19;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==CLASS) {
				{
				{
				State = 16;
				class_decl();
				}
				}
				State = 21;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 22;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Class_declContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode CLASS() { return GetToken(CPlusParser.CLASS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(CPlusParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Method_declContext[] method_decl() {
			return GetRuleContexts<Method_declContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public Method_declContext method_decl(int i) {
			return GetRuleContext<Method_declContext>(i);
		}
		public Class_declContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_class_decl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterClass_decl(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitClass_decl(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClass_decl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Class_declContext class_decl() {
		Class_declContext _localctx = new Class_declContext(Context, State);
		EnterRule(_localctx, 2, RULE_class_decl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 24;
			Match(CLASS);
			State = 25;
			Match(ID);
			State = 26;
			Match(T__0);
			State = 30;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 1784L) != 0)) {
				{
				{
				State = 27;
				method_decl();
				}
				}
				State = 32;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 33;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Method_declContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ID() { return GetToken(CPlusParser.ID, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PUBLIC() { return GetToken(CPlusParser.PUBLIC, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PRIVATE() { return GetToken(CPlusParser.PRIVATE, 0); }
		public Method_declContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_method_decl; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterMethod_decl(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitMethod_decl(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMethod_decl(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Method_declContext method_decl() {
		Method_declContext _localctx = new Method_declContext(Context, State);
		EnterRule(_localctx, 4, RULE_method_decl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==PUBLIC || _la==PRIVATE) {
				{
				State = 35;
				_la = TokenStream.LA(1);
				if ( !(_la==PUBLIC || _la==PRIVATE) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
			}

			State = 38;
			type();
			State = 39;
			Match(ID);
			State = 40;
			Match(T__0);
			State = 41;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public Numeric_typeContext numeric_type() {
			return GetRuleContext<Numeric_typeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public String_typeContext string_type() {
			return GetRuleContext<String_typeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Bool_typeContext bool_type() {
			return GetRuleContext<Bool_typeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Void_typeContext void_type() {
			return GetRuleContext<Void_typeContext>(0);
		}
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(Context, State);
		EnterRule(_localctx, 6, RULE_type);
		try {
			State = 47;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__2:
			case T__3:
				EnterOuterAlt(_localctx, 1);
				{
				State = 43;
				numeric_type();
				}
				break;
			case T__4:
				EnterOuterAlt(_localctx, 2);
				{
				State = 44;
				string_type();
				}
				break;
			case T__5:
				EnterOuterAlt(_localctx, 3);
				{
				State = 45;
				bool_type();
				}
				break;
			case T__6:
				EnterOuterAlt(_localctx, 4);
				{
				State = 46;
				void_type();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Numeric_typeContext : ParserRuleContext {
		public Numeric_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_numeric_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterNumeric_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitNumeric_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumeric_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Numeric_typeContext numeric_type() {
		Numeric_typeContext _localctx = new Numeric_typeContext(Context, State);
		EnterRule(_localctx, 8, RULE_numeric_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 49;
			_la = TokenStream.LA(1);
			if ( !(_la==T__2 || _la==T__3) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class String_typeContext : ParserRuleContext {
		public String_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_string_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterString_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitString_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitString_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public String_typeContext string_type() {
		String_typeContext _localctx = new String_typeContext(Context, State);
		EnterRule(_localctx, 10, RULE_string_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 51;
			Match(T__4);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Bool_typeContext : ParserRuleContext {
		public Bool_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_bool_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterBool_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitBool_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBool_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Bool_typeContext bool_type() {
		Bool_typeContext _localctx = new Bool_typeContext(Context, State);
		EnterRule(_localctx, 12, RULE_bool_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 53;
			Match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Void_typeContext : ParserRuleContext {
		public Void_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_void_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.EnterVoid_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ICPlusListener typedListener = listener as ICPlusListener;
			if (typedListener != null) typedListener.ExitVoid_type(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICPlusVisitor<TResult> typedVisitor = visitor as ICPlusVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVoid_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Void_typeContext void_type() {
		Void_typeContext _localctx = new Void_typeContext(Context, State);
		EnterRule(_localctx, 14, RULE_void_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 55;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,12,58,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,1,0,5,0,18,8,0,10,0,12,0,21,9,0,1,0,1,0,1,1,1,1,1,1,1,1,5,1,29,8,1,
		10,1,12,1,32,9,1,1,1,1,1,1,2,3,2,37,8,2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,
		3,1,3,3,3,48,8,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,1,7,0,0,8,0,2,4,6,8,10,
		12,14,0,2,1,0,9,10,1,0,3,4,55,0,19,1,0,0,0,2,24,1,0,0,0,4,36,1,0,0,0,6,
		47,1,0,0,0,8,49,1,0,0,0,10,51,1,0,0,0,12,53,1,0,0,0,14,55,1,0,0,0,16,18,
		3,2,1,0,17,16,1,0,0,0,18,21,1,0,0,0,19,17,1,0,0,0,19,20,1,0,0,0,20,22,
		1,0,0,0,21,19,1,0,0,0,22,23,5,0,0,1,23,1,1,0,0,0,24,25,5,8,0,0,25,26,5,
		11,0,0,26,30,5,1,0,0,27,29,3,4,2,0,28,27,1,0,0,0,29,32,1,0,0,0,30,28,1,
		0,0,0,30,31,1,0,0,0,31,33,1,0,0,0,32,30,1,0,0,0,33,34,5,2,0,0,34,3,1,0,
		0,0,35,37,7,0,0,0,36,35,1,0,0,0,36,37,1,0,0,0,37,38,1,0,0,0,38,39,3,6,
		3,0,39,40,5,11,0,0,40,41,5,1,0,0,41,42,5,2,0,0,42,5,1,0,0,0,43,48,3,8,
		4,0,44,48,3,10,5,0,45,48,3,12,6,0,46,48,3,14,7,0,47,43,1,0,0,0,47,44,1,
		0,0,0,47,45,1,0,0,0,47,46,1,0,0,0,48,7,1,0,0,0,49,50,7,1,0,0,50,9,1,0,
		0,0,51,52,5,5,0,0,52,11,1,0,0,0,53,54,5,6,0,0,54,13,1,0,0,0,55,56,5,7,
		0,0,56,15,1,0,0,0,4,19,30,36,47
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
