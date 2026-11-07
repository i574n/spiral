program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TTuple0 = record f0: TUS0; f1: TUS0; end;
function method0(v0: LongInt): TTuple0; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TupleCreate0(f0: TUS0; f1: TUS0): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: LongInt): TTuple0;
var
  v1: Boolean;
  v2: TUS0;
  v3: TUS0;
  v4: TUS0;
  v5: TUS0;
begin
  v1 := v0 = 0;
  if v1 then begin
      v2 := US0_None;
      v3 := US0_None;
      Result := TupleCreate0(v2, v3);
  end else begin
      v4 := US0_Some(v0);
      v5 := US0_None;
      Result := TupleCreate0(v4, v5);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: TUS0;
  tmp3: TTuple0;
  v3: LongInt;
  v4: Boolean;
  v6: LongInt;
begin
  v0 := 7;
  tmp3 := method0(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  case v1.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v3 := v1.c1_0;
          case v2.tag of
              0: begin
                  v4 := v3 = 7;
                  if v4 then begin
                      Result := 0;
                  end else begin
                      Result := 1;
                  end;
              end;
              1: begin
                  v6 := v2.c1_0;
                  Result := 1;
              end;
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
