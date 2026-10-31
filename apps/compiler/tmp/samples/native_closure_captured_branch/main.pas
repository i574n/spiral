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
  Ta_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  Tb_c1 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function ClosureCreate1(v0: LongInt): TFun0; forward;
function method0(v0: TFun0): LongInt; forward;
function Ta_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Ta_c0;
begin
  c := Ta_c0.Create; c.v0 := v0;
  Result := c;
end;
function Tb_c1.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate1(v0: LongInt): TFun0;
var c: Tb_c1;
begin
  c := Tb_c1.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0): LongInt;
begin
  Result := v0.Invoke(40);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
  v5: TFun0;
begin
  v0 := 2;
  v1 := 3;
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
