program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  THeap0 = record l0: Single; l1: AnsiString; end;
function HeapCreate0(a0: Single; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: AnsiString;
  v2: THeap0;
  v3: Single;
  v4: AnsiString;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 1.5;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := v2.l0;
  v4 := v2.l1;
  v5 := v3 = 1.5;
  if v5 then begin
      v6 := v4 = 'hi';
      v7 := v6;
  end else begin
      v7 := False;
  end;
  if v7 then begin
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
