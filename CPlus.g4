grammar CPlus;

/*
  Parser Rules
*/

program: class_decl* EOF;

class_decl: CLASS ID '{' (method_decl)* '}';
method_decl: (PUBLIC | PRIVATE)? type ID '{' '}';
type: numeric_type | string_type | bool_type | void_type;
numeric_type: 'float' | 'int'; 
string_type: 'string';
bool_type: 'bool';
void_type: 'void';

/*
  Lexer Rules
*/

CLASS: 'class';
PUBLIC: 'public';
PRIVATE: 'private';


ID: [_a-zA-Z][_a-zA-Z0-9]*;



// Skip sapces, tabs, newlines
WS: [ \t\r\n\f]+ -> skip;

fragment A: [aA];
fragment B: [bB];
fragment C: [cC];
fragment D: [dD];
fragment E: [eE];
fragment F: [fF];
fragment G: [gG];
fragment H: [hH];
fragment I: [iI];
fragment J: [jJ];
fragment K: [kK];
fragment L: [lL];
fragment M: [mM];
fragment N: [nN];
fragment O: [oO];
fragment P: [pP];
fragment Q: [qQ];
fragment R: [rR];
fragment S: [sS];
fragment T: [tT];
fragment U: [uU];
fragment V: [vV];
fragment W: [wW];
fragment X: [xX];
fragment Y: [yY];
fragment Z: [zZ];