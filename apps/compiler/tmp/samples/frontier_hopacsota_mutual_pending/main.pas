program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
function is_odd_1(v0: LongInt): Boolean; forward;
function is_even_0(v0: LongInt): Boolean; forward;
function is_odd_1(v0: LongInt): Boolean;
var
  v1: Boolean;
  v2: LongInt;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := False;
  end else begin
      v2 := v0 - 1;
      Result := is_even_0(v2);
  end;
end;
function is_even_0(v0: LongInt): Boolean;
var
  v1: Boolean;
  v2: LongInt;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := True;
  end else begin
      v2 := v0 - 1;
      Result := is_odd_1(v2);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
begin
  v0 := 10;
  v1 := is_even_0(v0);
  if v1 then begin
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
