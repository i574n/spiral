program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TTuple0 = record f0: Double; f1: Double; end;
function method0(v0: LongInt): TTuple0; forward;
function TupleCreate0(f0: Double; f1: Double): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: LongInt): TTuple0;
var
  v1: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := TupleCreate0(Double(0.0), Double(0.0));
  end else begin
      Result := TupleCreate0(Double(1.5), Double(2.5));
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Double;
  v2: Double;
  tmp3: TTuple0;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
begin
  v0 := 7;
  tmp3 := method0(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  v3 := v1 = Double(1.5);
  if v3 then begin
      v4 := v2 = Double(2.5);
      v5 := v4;
  end else begin
      v5 := False;
  end;
  if v5 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
procedure SpiralRun;
begin
  {$IFDEF WINDOWS}SetTextCodePage(Output, CP_UTF8); SetTextCodePage(StdErr, CP_UTF8);{$ENDIF}
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  Flush(Output);
end;
{$IFNDEF WINDOWS}
function SpiralThreadMain(p: Pointer): PtrInt;
begin
  SpiralRun;
  Result := 0;
end;
var SpiralThread, SpiralThreadId: TThreadID;
{$ENDIF}
begin
  {$IFDEF WINDOWS}
  SpiralRun;
  Halt(SpiralExitCode);
  {$ELSE}
  SpiralThread := BeginThread(@SpiralThreadMain, nil, SpiralThreadId, 268435456);
  WaitForThreadTerminate(SpiralThread, 0);
  Halt(SpiralExitCode and 255);
  {$ENDIF}
end.
