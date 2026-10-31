program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tleft_c0 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): LongInt; override; end;
  Tright_c1 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: AnsiString): TFun0; forward;
function ClosureCreate1(v0: AnsiString): TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
function Tleft_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := LongInt(Length(v0));
  v3 := v2 + v1;
  Result := v3;
end;
function ClosureCreate0(v0: AnsiString): TFun0;
var c: Tleft_c0;
begin
  c := Tleft_c0.Create; c.v0 := v0;
  Result := c;
end;
function Tright_c1.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := LongInt(Length(v0));
  v3 := v2 + v1;
  v4 := v3 - 1;
  Result := v4;
end;
function ClosureCreate1(v0: AnsiString): TFun0;
var c: Tright_c1;
begin
  c := Tright_c1.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(39);
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: Boolean;
  v5: TFun0;
begin
  v0 := 'abc';
  v1 := 'wxyz';
  v2 := True;
  if v2 then begin
      v5 := ClosureCreate0(v0);
  end else begin
      v5 := ClosureCreate1(v1);
  end;
  Result := method0(v5);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
