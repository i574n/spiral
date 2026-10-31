program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TMut0 = class l0: AnsiString; end;
procedure method2(v0: TMut0; v1: AnsiString); forward;
function format_real_1(v0: LongInt): AnsiString; forward;
function method0: AnsiString; forward;
function MutCreate0(a0: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
procedure method2(v0: TMut0; v1: AnsiString);
var
  v2: AnsiString;
  v3: AnsiString;
begin
  v2 := v0.l0;
  v3 := v2 + v1 ;
  v0.l0 := v3;
end;
function format_real_1(v0: LongInt): AnsiString;
var
  v1: AnsiString;
  v2: TMut0;
  v3: AnsiString;
  v4: AnsiString;
begin
  v1 := '';
  v2 := MutCreate0(v1);
  v3 := IntToStr(v0);
  method2(v2, v3);
  v4 := v2.l0;
  Result := v4;
end;
function method0: AnsiString;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: LongInt;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
begin
  v0 := 'Some';
  v1 := '(';
  v2 := v0 + v1 ;
  v3 := 1;
  v4 := format_real_1(v3);
  v5 := v2 + v4 ;
  v6 := ')';
  v7 := v5 + v6 ;
  Result := v7;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: Boolean;
begin
  v0 := method0;
  v1 := 'x: ';
  v2 := v1 + v0 ;
  v3 := v2 = '';
  if v3 then begin
      Result := 1;
  end else begin
      Result := 0;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
