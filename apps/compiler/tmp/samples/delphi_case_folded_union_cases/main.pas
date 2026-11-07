program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt;  end;
function US0_Foo_0: TUS0;
begin
  Result.tag := 0; 
end;
function US0_FOO_1: TUS0;
begin
  Result.tag := 1; 
end;
function US0_Bar: TUS0;
begin
  Result.tag := 2; 
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v1: TUS0;
  v4: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := US0_Foo_0;
  v1 := US0_FOO_1;
  case v0.tag of
      2: begin
          v4 := 100;
      end;
      1: begin
          v4 := 10;
      end;
      0: begin
          v4 := 1;
      end;
  end;
  case v1.tag of
      2: begin
          v7 := 100;
      end;
      1: begin
          v7 := 10;
      end;
      0: begin
          v7 := 1;
      end;
  end;
  v8 := v4 + v7;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
