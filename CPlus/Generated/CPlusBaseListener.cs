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


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ICPlusListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class CPlusBaseListener : ICPlusListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] CPlusParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] CPlusParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.class_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClass_decl([NotNull] CPlusParser.Class_declContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.class_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClass_decl([NotNull] CPlusParser.Class_declContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.method_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMethod_decl([NotNull] CPlusParser.Method_declContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.method_decl"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMethod_decl([NotNull] CPlusParser.Method_declContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] CPlusParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] CPlusParser.TypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.numeric_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNumeric_type([NotNull] CPlusParser.Numeric_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.numeric_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNumeric_type([NotNull] CPlusParser.Numeric_typeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.string_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterString_type([NotNull] CPlusParser.String_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.string_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitString_type([NotNull] CPlusParser.String_typeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.bool_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBool_type([NotNull] CPlusParser.Bool_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.bool_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBool_type([NotNull] CPlusParser.Bool_typeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CPlusParser.void_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVoid_type([NotNull] CPlusParser.Void_typeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CPlusParser.void_type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVoid_type([NotNull] CPlusParser.Void_typeContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
