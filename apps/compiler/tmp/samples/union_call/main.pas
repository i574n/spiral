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
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  TUS0 = record tag: LongInt; c1_0: TFun0; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Call(a0: TFun0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: Boolean;
  v5: TUS0;
  v6: TFun0;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := ClosureCreate0(v0);
  v2 := True;
  if v2 then begin
      v5 := US0_Call(v1);
  end else begin
      v5 := US0_Missing;
  end;
  case v5.tag of
      1: begin
          v6 := v5.c1_0;
          v7 := v6.Invoke(4);
          v8 := v7 = 7;
          if v8 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
