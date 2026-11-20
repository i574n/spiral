program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: TUS0; c1_1: TUH0; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function method0(v0: TUH0; v1: TUH0): Boolean; forward;
function US0_Vowel(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_1);
end;
var UH0_Nil_shared: TUH0 = nil;
function UH0_Nil: TUH0;
begin
  if UH0_Nil_shared = nil then begin UH0_Nil_shared := TUH0.Create; UH0_Nil_shared.tag := 0; UH0_Nil_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Nil_shared;
end;
function UH0_Cons(a0: TUS0; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function method0(v0: TUH0; v1: TUH0): Boolean;
var
  tmp0: LongInt;
  v2: TUS0;
  v3: TUH0;
  v4: TUS0;
  v5: TUH0;
  v9: Boolean;
  tmp6: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: Boolean;
begin
  while True do begin
      if (v1.tag = v0.tag) then tmp0 := v1.tag else tmp0 := -1;
      case tmp0 of
          1: begin
              v2 := v1.c1_0;
              v3 := v1.c1_1;
              v4 := v0.c1_0;
              v5 := v0.c1_1;
              SpiralRetain(v3);
              SpiralRetain(v5);
              SpiralRelease(v0);
              SpiralRelease(v1);
              if (v2.tag = v4.tag) then tmp6 := v2.tag else tmp6 := -1;
              case tmp6 of
                  0: begin
                      v6 := v2.c0_0;
                      v7 := v4.c0_0;
                      v8 := v6 = v7;
                      v9 := v8;
                  end;
                  else begin
                      v9 := False;
                  end;
              end;
              if v9 then begin
                  v0 := v5;
                  v1 := v3;
                  Continue;
              end else begin
                  SpiralRelease(v3);
                  SpiralRelease(v5);
                  Result := False;
                  Exit;
              end;
          end;
          0: begin
              SpiralRelease(v0);
              SpiralRelease(v1);
              Result := True;
              Exit;
          end;
          else begin
              SpiralRelease(v0);
              SpiralRelease(v1);
              Result := False;
              Exit;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: LongInt;
  v3: TUS0;
  v4: LongInt;
  v5: TUS0;
  v6: TUH0;
  v7: TUH0;
  v8: TUH0;
  v9: TUH0;
  v10: TUH0;
  v11: TUH0;
  v12: TUH0;
  v13: TUH0;
  v17: Boolean;
  tmp15: LongInt;
  v14: LongInt;
  v15: LongInt;
  v16: Boolean;
  v23: Boolean;
  v21: Boolean;
  tmp21: LongInt;
  v18: LongInt;
  v19: LongInt;
  v20: Boolean;
  v22: Boolean;
  v30: Boolean;
  v27: Boolean;
  tmp28: LongInt;
  v24: LongInt;
  v25: LongInt;
  v26: Boolean;
  v38: Boolean;
  v34: Boolean;
  tmp34: LongInt;
  v31: LongInt;
  v32: LongInt;
  v33: Boolean;
  v36: Boolean;
  v37: Boolean;
begin
  v0 := 1;
  v1 := US0_Vowel(v0);
  v2 := 1;
  v3 := US0_Vowel(v2);
  v4 := 2;
  v5 := US0_Vowel(v4);
  v6 := UH0_Nil;
  SpiralRetain(v6);
  v7 := UH0_Cons(v5, v6);
  SpiralRetain(v7);
  SpiralRelease(v6);
  v8 := UH0_Cons(v1, v7);
  SpiralRelease(v7);
  v9 := UH0_Nil;
  SpiralRetain(v9);
  v10 := UH0_Cons(v5, v9);
  SpiralRetain(v10);
  SpiralRelease(v9);
  v11 := UH0_Cons(v3, v10);
  SpiralRelease(v10);
  v12 := UH0_Nil;
  SpiralRetain(v12);
  v13 := UH0_Cons(v1, v12);
  SpiralRelease(v12);
  if (v1.tag = v3.tag) then tmp15 := v1.tag else tmp15 := -1;
  case tmp15 of
      0: begin
          v14 := v1.c0_0;
          v15 := v3.c0_0;
          v16 := v14 = v15;
          v17 := v16;
      end;
      else begin
          v17 := False;
      end;
  end;
  if v17 then begin
      if (v1.tag = v5.tag) then tmp21 := v1.tag else tmp21 := -1;
      case tmp21 of
          0: begin
              v18 := v1.c0_0;
              v19 := v5.c0_0;
              v20 := v18 = v19;
              v21 := v20;
          end;
          else begin
              v21 := False;
          end;
      end;
      v22 := v21 = False;
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      if (v1.tag = v3.tag) then tmp28 := v1.tag else tmp28 := -1;
      case tmp28 of
          0: begin
              v24 := v1.c0_0;
              v25 := v3.c0_0;
              v26 := v24 = v25;
              v27 := v26;
          end;
          else begin
              v27 := False;
          end;
      end;
      if v27 then begin
          SpiralRetain(v8);
          SpiralRetain(v11);
          v30 := method0(v11, v8);
      end else begin
          v30 := False;
      end;
  end else begin
      v30 := False;
  end;
  SpiralRelease(v11);
  if v30 then begin
      if (v1.tag = v5.tag) then tmp34 := v1.tag else tmp34 := -1;
      case tmp34 of
          0: begin
              v31 := v1.c0_0;
              v32 := v5.c0_0;
              v33 := v31 = v32;
              v34 := v33;
          end;
          else begin
              v34 := False;
          end;
      end;
      if v34 then begin
          SpiralRetain(v8);
          SpiralRetain(v13);
          v36 := method0(v13, v8);
      end else begin
          v36 := False;
      end;
      v37 := v36 = False;
      v38 := v37;
  end else begin
      v38 := False;
  end;
  SpiralRelease(v8);
  SpiralRelease(v13);
  if v38 then begin
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
  if UH0_Nil_shared <> nil then UH0_Nil_shared.Free;
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
