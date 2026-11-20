program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
function method1(v0: LongInt): LongInt; forward;
function method0(v0: LongInt): LongInt; forward;
function method1(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
begin
  while True do begin
      v1 := v0 - 1;
      v2 := v1 = 0;
      if v2 then begin
          Result := 0;
          Exit;
      end else begin
          v0 := v1;
          Continue;
      end;
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := 0;
  end else begin
      Result := method1(v0);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 1000000;
  Result := method0(v0);
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
