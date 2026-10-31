program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: LongInt; c2_0: Boolean; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  Tclosure0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): TUS0; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function method0(v0: TFun0; v1: LongInt): TUS0; forward;
function US0_Idle: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Hit(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Flag(a0: Boolean): TUS0;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function Tclosure0.Invoke(v1: LongInt): TUS0;
var
  v2: Boolean;
begin
  v2 := v1 = v0;
  Result := US0_Flag(v2);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tclosure0;
begin
  c := Tclosure0.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: TFun0; v1: LongInt): TUS0;
begin
  Result := v0.Invoke(v1);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: TUS0;
  v8: LongInt;
  v4: Boolean;
  v3: LongInt;
  v9: LongInt;
begin
  v0 := 2;
  v1 := ClosureCreate0(v0);
  v2 := method0(v1, v0);
  case v2.tag of
      2: begin
          v4 := v2.c2_0;
          if v4 then begin
              v8 := 11;
          end else begin
              v8 := 5;
          end;
      end;
      1: begin
          v3 := v2.c1_0;
          v8 := v3;
      end;
      0: begin
          v8 := 3;
      end;
  end;
  v9 := v8 + 31;
  Result := v9;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
