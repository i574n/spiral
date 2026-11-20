program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  THeap0 = record l0: LongInt; l1: AnsiString; l2: Boolean; end;
function HeapCreate0(a0: LongInt; a1: AnsiString; a2: Boolean): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1; Result.l2 := a2;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: Boolean;
  v3: THeap0;
  v4: LongInt;
  v5: AnsiString;
  v6: Boolean;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
  v10: Boolean;
begin
  v0 := 7;
  v1 := 'hi';
  v2 := True;
  v3 := HeapCreate0(v0, v1, v2);
  v4 := v3.l0;
  v5 := v3.l1;
  v6 := v3.l2;
  v7 := v4 = 7;
  if v7 then begin
      v8 := v5 = 'hi';
      v9 := v8;
  end else begin
      v9 := False;
  end;
  v10 := v9 and v6;
  if v10 then begin
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
