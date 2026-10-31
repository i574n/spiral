program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TUH1 = class;
  TUH1 = class tag: LongInt; c0_0: TUH0; end;
  TUH0 = class tag: LongInt; c0_0: TUH1; end;
function UH1_B(a0: TUH0): TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; Result.c0_0 := a0;
end;
var UH1_StopB_shared: TUH1 = nil;
function UH1_StopB: TUH1;
begin
  if UH1_StopB_shared = nil then begin UH1_StopB_shared := TUH1.Create; UH1_StopB_shared.tag := 1; end;
  Result := UH1_StopB_shared;
end;
function UH0_A(a0: TUH1): TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; Result.c0_0 := a0;
end;
var UH0_StopA_shared: TUH0 = nil;
function UH0_StopA: TUH0;
begin
  if UH0_StopA_shared = nil then begin UH0_StopA_shared := TUH0.Create; UH0_StopA_shared.tag := 1; end;
  Result := UH0_StopA_shared;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v5: TUH0;
  v1: TUH0;
  v2: TUH1;
  v6: TUH1;
begin
  v0 := True;
  if v0 then begin
      v1 := UH0_StopA;
      v2 := UH1_B(v1);
      v5 := UH0_A(v2);
  end else begin
      v5 := UH0_StopA;
  end;
  case v5.tag of
      0: begin
          v6 := v5.c0_0;
          Result := 0;
      end;
      1: begin
          Result := 0;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
