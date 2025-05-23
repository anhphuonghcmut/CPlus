grammar CPlus;

@lexer::header {
using CPlus.Exceptions;
}


program: class_decl* EOF;

/**** Class ****/
class_decl: CLASS ID LP members* RP;
members: (field_decl | method_decl);

/**** Field ****/
field_decl: (PUBLIC | PRIVATE)? var_decl;
var_decl: IMMUTABLE? data_type attribute SM;


method_decl: (PUBLIC | PRIVATE)? (data_type | VOID) ID LB parameter? RB method_body;
method_body: LP var_decl* statement* RP;


/****************************************************************************/
/*																	 		*/
/*								6.Statements 								*/
/* 																			*/
/****************************************************************************/

statement: 
    assignment_statement
	| return_statement
	| method_invocation_statement;
assignment_statement: (ID | expr9) ASSIGN expr SM;
return_statement: RETURN expr? SM;
method_invocation_statement: member_access SM;
member_access: (ID | expr) DOT ID LB list_of_expr? RB;



/****************************************************************************/
/*																	 		*/
/*								5.Expressions								*/
/* 																			*/
/****************************************************************************/

// expr: expr1 (LT | GT | LE | GE) expr1 | expr1; // not support yet
expr: expr3 (EQUAL | NOT_EQUAL) expr3 | expr3;
// expr2: expr2 (AND | OR) expr3 | expr3; // not support yet
expr3: expr3 ( ADD | SUB) expr4 | expr4;
expr4: expr4 (MUL | DIV) expr6 | expr6; // | MOD | INT_DIV not support yet
expr6: NOT expr6 | expr7;
expr7: ( ADD | SUB) expr7 | expr9;
//expr8: expr9 LSB expr RSB | expr9; // array index access, not support yet
expr9:
	expr9 DOT ID (LB list_of_expr? RB)? // Method call or Access to a field
	| expr10;
//expr10: NEW ID LB (list_of_expr)? RB expr10? | expr11; // TODO: handle constructor
expr10: NEW ID LB RB | expr11;
//expr11: LB expr RB | ID | literal | THIS | NIL;
expr11: LB expr RB | ID | literal | THIS;
list_of_expr: expr (CM expr)*;




/****************************************************************************/
/*																	 		*/
/*								4.Type										*/
/* 																			*/
/****************************************************************************/
data_type:  type_not_void | class_type;
type_not_void: INT | FLOAT | BOOLEAN | STRING;
string_type: 'string';
bool_type: 'bool';
literal: INTLIT | FLOATLIT | BOOLLIT | STRINGLIT;
class_type: ID; //test

/****************************************************************************/
/*																	 		*/
/*								Utilities									*/
/* 																			*/
/****************************************************************************/

attribute: ID (ASSIGN expr)?;
parameter: data_type ID parameter_list*;
parameter_list: CM data_type ID;


/****************************************************************************/
/*																	 		*/
/*								3.Lexers									*/
/* 																			*/
/****************************************************************************/

/****** COMMENT *****/
LINE_CMT: '#' ~[\r\n]* -> skip;
BLOCK_CMT: '/*' .*? '*/' -> skip;


/****** KEYWORDS *****/
BOOLEAN: 'boolean';
CLASS: 'class';
PUBLIC: 'public';
PRIVATE: 'private';
IMMUTABLE: 'immut';
FLOAT: 'float';
INT: 'int';
NEW: 'new';
STRING: 'string';
RETURN: 'return';
VOID: 'void';
THIS: 'this';

/****** OPERATORS *****/
ADD: '+';
SUB: '-';
MUL: '*';
DIV: '/';
NOT: '!';
ASSIGN: '=';
NOT_EQUAL: '!=';
EQUAL: '==';

/****** SEPARATORS *****/
LSB: '[';
RSB: ']';
LP: '{';
RP: '}';
LB: '(';
RB: ')';
SM: ';';
CL: ':';
DOT: '.';
CM: ',';

/****** LITERALS *********/
BOOLLIT: 'true' | 'false';

STRINGLIT
    : '"' STR_CHAR* '"'
      {
          Text = Text.Substring(1, Text.Length - 2);
      }
    ;
FLOATLIT:
	DIGIT+ DOT
	| DIGIT+ DOT DIGIT+;
INTLIT: DIGIT+;
ID: [_a-zA-Z][_a-zA-Z0-9]*;


UNCLOSE_STRING
    : '"' STR_CHAR*
      {
          throw new UncloseStringException(Text, Line, Column);
      }
    ;

ILLEGAL_ESCAPE
    : '"' STR_CHAR* ESC_ILLEGAL
      {
          throw new IllegalEscapeException(Text, Line, Column);
      }
    ;


/**** FRAGMENT *****/
fragment DIGIT: [0-9];
// fragment STR_CHAR: ~[\r\n"\\] | ('\\' [bfrnt"\\]);

fragment STR_CHAR: ~[\b\t\n\f\r"\\] | ESC_SEQ;

fragment ESC_SEQ: '\\' [btnfr"\\];
fragment ESC_ILLEGAL: '\\' ~[btnfr"\\] | '\\';
WS: [ \t\r\f]+ -> skip; // skip spaces, tabs, form feed, newline
NEWLINE: '\n'+ -> skip;
// Skip sapces, tabs, newlines
ERROR_CHAR:
	. {
		throw new ErrorTokenException(Text, Line, Column);
	};