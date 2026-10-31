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
  Tf_c0 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: AnsiString): TFun0; forward;
function apply_1(v0: TFun0; v1: LongInt): LongInt; forward;
function method0(v0: TFun0; v1: LongInt): LongInt; forward;
function method2(v0: TFun0; v1: LongInt): LongInt; forward;
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := LongInt(Length(v0));
  v3 := v2 + v1;
  Result := v3;
end;
function ClosureCreate0(v0: AnsiString): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function apply_1(v0: TFun0; v1: LongInt): LongInt;
begin
  Result := v0.Invoke(v1);
end;
function method0(v0: TFun0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := apply_1(v0, v1);
  v3 := v2 + 1;
  Result := v3;
end;
function method2(v0: TFun0; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
begin
  v2 := apply_1(v0, v1);
  v3 := v2 + 2;
  Result := v3;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TFun0;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
begin
  v0 := 'abc';
  v1 := ClosureCreate0(v0);
  v2 := 16;
  v3 := method0(v1, v2);
  v4 := 17;
  v5 := method2(v1, v4);
  v6 := v3 + v5;
  Result := v6;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
