program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: THeap0; end;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Box(a0: THeap0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: THeap0;
  v2: Boolean;
  v5: TUS0;
  v6: THeap0;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 7;
  v1 := HeapCreate0(v0);
  v2 := True;
  if v2 then begin
      v5 := US0_Box(v1);
  end else begin
      v5 := US0_Missing;
  end;
  case v5.tag of
      1: begin
          v6 := v5.c1_0;
          v7 := v6.l0;
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
