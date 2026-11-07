program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; c1_0: LongInt; c2_0: LongInt; end;
function method1(v0: LongInt): LongInt; forward;
function area_0(v0: TUS0): LongInt; forward;
function US0_Circle(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Square(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Triangle(a0: LongInt): TUS0;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function US0_Dot: TUS0;
begin
  Result.tag := 3; 
end;
function method1(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v1 := v0 * v0;
  v2 := 7 * v0;
  v3 := v1 + v2;
  v4 := v3 - 3;
  Result := v4;
end;
function area_0(v0: TUS0): LongInt;
var
  v1: LongInt;
  v3: LongInt;
  v5: LongInt;
begin
  case v0.tag of
      0: begin
          v1 := v0.c0_0;
          Result := method1(v1);
      end;
      3: begin
          Result := 0;
      end;
      1: begin
          v3 := v0.c1_0;
          Result := method1(v3);
      end;
      2: begin
          v5 := v0.c2_0;
          Result := method1(v5);
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
begin
  v0 := 4;
  v1 := US0_Square(v0);
  Result := area_0(v1);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
