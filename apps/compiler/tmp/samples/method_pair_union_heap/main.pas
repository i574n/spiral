program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  THeap0 = record l0: LongInt; end;
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TTuple0 = record f0: TUS0; f1: THeap0; end;
function method0(v0: LongInt; v1: THeap0): TTuple0; forward;
function HeapCreate0(a0: LongInt): THeap0;
begin
  Result.l0 := a0;
end;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TupleCreate0(f0: TUS0; f1: THeap0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: LongInt; v1: THeap0): TTuple0;
var
  v2: TUS0;
begin
  v2 := US0_Some(v0);
  Result := TupleCreate0(v2, v1);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: THeap0;
  v3: TUS0;
  v4: THeap0;
  tmp5: TTuple0;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 4;
  v2 := HeapCreate0(v1);
  tmp5 := method0(v0, v2);
  v3 := tmp5.f0;
  v4 := tmp5.f1;
  case v3.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v5 := v3.c1_0;
          v6 := v4.l0;
          v7 := v5 + v6;
          v8 := v7 = 7;
          if v8 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
