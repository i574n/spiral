program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TArray0 = array of LongInt;
  TTuple0 = record f0: TArray0; f1: TArray0; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; v1: LongInt; function Invoke(v2: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0; forward;
function TupleCreate0(f0: TArray0; f1: TArray0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v2: LongInt): TTuple0;
var
  v3: TArray0;
  tmp1: TArray0;
  v4: TArray0;
  tmp3: TArray0;
  v5: Boolean;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v3 := tmp1;
  tmp3 := nil;
  SetLength(tmp3, 1);
  v4 := tmp3;
  v5 := v2 = 0;
  if v5 then begin
      v3[0] := 0;
      v4[0] := 0;
      Result := TupleCreate0(v3, v4);
  end else begin
      v3[0] := v0;
      v4[0] := v1;
      Result := TupleCreate0(v3, v4);
  end;
end;
function ClosureCreate0(v0: LongInt; v1: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: TFun0;
  v3: TArray0;
  v4: TArray0;
  tmp5: TTuple0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := ClosureCreate0(v0, v1);
  tmp5 := v2.Invoke(1);
  v3 := tmp5.f0;
  v4 := tmp5.f1;
  v5 := v3[0];
  v6 := v4[0];
  v7 := v5 + v6;
  v8 := v7 = 7;
  if v8 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
