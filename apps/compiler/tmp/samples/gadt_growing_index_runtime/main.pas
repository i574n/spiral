program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH1 = class;
  TUH2 = class;
  TUH3 = class;
  TUH4 = class;
  TUH5 = class;
  TUH6 = class;
  TUH7 = class;
  TUH8 = class;
  TUH9 = class;
  TUH10 = class;
  TUH0 = class(TSpiralRc) tag: LongInt;  end;
  TUH3 = class(TSpiralRc) tag: LongInt; c1_0: TUH0; procedure DropFields; override; end;
  TUH5 = class(TSpiralRc) tag: LongInt; c1_0: TUH3; procedure DropFields; override; end;
  TUH7 = class(TSpiralRc) tag: LongInt; c1_0: TUH5; procedure DropFields; override; end;
  TUH9 = class(TSpiralRc) tag: LongInt; c1_0: TUH9; procedure DropFields; override; end;
  TUH8 = class(TSpiralRc) tag: LongInt; c0_0: TUH9; c1_0: TUH8; c2_0: TUH8; c2_1: TUH8; procedure DropFields; override; end;
  TUH6 = class(TSpiralRc) tag: LongInt; c0_0: TUH7; c1_0: TUH8; c2_0: TUH6; c2_1: TUH6; procedure DropFields; override; end;
  TUH4 = class(TSpiralRc) tag: LongInt; c0_0: TUH5; c1_0: TUH6; c2_0: TUH4; c2_1: TUH4; procedure DropFields; override; end;
  TUH2 = class(TSpiralRc) tag: LongInt; c0_0: TUH3; c1_0: TUH4; c2_0: TUH2; c2_1: TUH2; procedure DropFields; override; end;
  TUH1 = class(TSpiralRc) tag: LongInt; c0_0: TUH0; c1_0: TUH2; c2_0: TUH1; c2_1: TUH1; procedure DropFields; override; end;
  TUH10 = class(TSpiralRc) tag: LongInt; c0_0: TUH1; c1_0: TUH10; c1_1: TUH10; procedure DropFields; override; end;
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
function size_7(v0: TUH8): LongInt; forward;
function size_6(v0: TUH8): LongInt; forward;
function size_5(v0: TUH8): LongInt; forward;
function size_4(v0: TUH6): LongInt; forward;
function size_3(v0: TUH4): LongInt; forward;
function size_2(v0: TUH2): LongInt; forward;
function size_1(v0: TUH1): LongInt; forward;
function size_0(v0: TUH10): LongInt; forward;
var UH0_VZ_shared: TUH0 = nil;
function UH0_VZ: TUH0;
begin
  if UH0_VZ_shared = nil then begin UH0_VZ_shared := TUH0.Create; UH0_VZ_shared.tag := 0; UH0_VZ_shared.refc := High(LongInt) div 2; end;
  Result := UH0_VZ_shared;
end;
procedure TUH3.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH3_VZ_shared: TUH3 = nil;
function UH3_VZ: TUH3;
begin
  if UH3_VZ_shared = nil then begin UH3_VZ_shared := TUH3.Create; UH3_VZ_shared.tag := 0; UH3_VZ_shared.refc := High(LongInt) div 2; end;
  Result := UH3_VZ_shared;
end;
function UH3_VS(a0: TUH0): TUH3;
begin
  Result := TUH3.Create; Result.tag := 1; Result.c1_0 := a0;
end;
procedure TUH5.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH5_VZ_shared: TUH5 = nil;
function UH5_VZ: TUH5;
begin
  if UH5_VZ_shared = nil then begin UH5_VZ_shared := TUH5.Create; UH5_VZ_shared.tag := 0; UH5_VZ_shared.refc := High(LongInt) div 2; end;
  Result := UH5_VZ_shared;
end;
function UH5_VS(a0: TUH3): TUH5;
begin
  Result := TUH5.Create; Result.tag := 1; Result.c1_0 := a0;
end;
procedure TUH7.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH7_VZ_shared: TUH7 = nil;
function UH7_VZ: TUH7;
begin
  if UH7_VZ_shared = nil then begin UH7_VZ_shared := TUH7.Create; UH7_VZ_shared.tag := 0; UH7_VZ_shared.refc := High(LongInt) div 2; end;
  Result := UH7_VZ_shared;
end;
function UH7_VS(a0: TUH5): TUH7;
begin
  Result := TUH7.Create; Result.tag := 1; Result.c1_0 := a0;
end;
procedure TUH9.DropFields;
begin
  SpiralRelease(c1_0);
end;
var UH9_VZ_shared: TUH9 = nil;
function UH9_VZ: TUH9;
begin
  if UH9_VZ_shared = nil then begin UH9_VZ_shared := TUH9.Create; UH9_VZ_shared.tag := 0; UH9_VZ_shared.refc := High(LongInt) div 2; end;
  Result := UH9_VZ_shared;
end;
function UH9_VS(a0: TUH9): TUH9;
begin
  Result := TUH9.Create; Result.tag := 1; Result.c1_0 := a0;
end;
procedure TUH8.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c2_0); SpiralRelease(c2_1);
end;
function UH8_Var(a0: TUH9): TUH8;
begin
  Result := TUH8.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH8_Lam(a0: TUH8): TUH8;
begin
  Result := TUH8.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function UH8_App(a0: TUH8; a1: TUH8): TUH8;
begin
  Result := TUH8.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1;
end;
procedure TUH6.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c2_0); SpiralRelease(c2_1);
end;
function UH6_Var(a0: TUH7): TUH6;
begin
  Result := TUH6.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH6_Lam(a0: TUH8): TUH6;
begin
  Result := TUH6.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function UH6_App(a0: TUH6; a1: TUH6): TUH6;
begin
  Result := TUH6.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1;
end;
procedure TUH4.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c2_0); SpiralRelease(c2_1);
end;
function UH4_Var(a0: TUH5): TUH4;
begin
  Result := TUH4.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH4_Lam(a0: TUH6): TUH4;
begin
  Result := TUH4.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function UH4_App(a0: TUH4; a1: TUH4): TUH4;
begin
  Result := TUH4.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1;
end;
procedure TUH2.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c2_0); SpiralRelease(c2_1);
end;
function UH2_Var(a0: TUH3): TUH2;
begin
  Result := TUH2.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH2_Lam(a0: TUH4): TUH2;
begin
  Result := TUH2.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function UH2_App(a0: TUH2; a1: TUH2): TUH2;
begin
  Result := TUH2.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1;
end;
procedure TUH1.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c2_0); SpiralRelease(c2_1);
end;
function UH1_Var(a0: TUH0): TUH1;
begin
  Result := TUH1.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH1_Lam(a0: TUH2): TUH1;
begin
  Result := TUH1.Create; Result.tag := 1; Result.c1_0 := a0;
end;
function UH1_App(a0: TUH1; a1: TUH1): TUH1;
begin
  Result := TUH1.Create; Result.tag := 2; Result.c2_0 := a0; Result.c2_1 := a1;
end;
procedure TUH10.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c1_0); SpiralRelease(c1_1);
end;
function UH10_Lam(a0: TUH1): TUH10;
begin
  Result := TUH10.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function UH10_App(a0: TUH10; a1: TUH10): TUH10;
begin
  Result := TUH10.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function size_7(v0: TUH8): LongInt;
var
  v5: TUH8;
  v6: TUH8;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH8;
  v3: LongInt;
  v4: LongInt;
  v1: TUH9;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_6(v5);
          v8 := 1 + v7;
          v9 := size_6(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_7(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_6(v0: TUH8): LongInt;
var
  v5: TUH8;
  v6: TUH8;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH8;
  v3: LongInt;
  v4: LongInt;
  v1: TUH9;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_6(v5);
          v8 := 1 + v7;
          v9 := size_6(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_7(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_5(v0: TUH8): LongInt;
var
  v5: TUH8;
  v6: TUH8;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH8;
  v3: LongInt;
  v4: LongInt;
  v1: TUH9;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_6(v5);
          v8 := 1 + v7;
          v9 := size_6(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_7(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_4(v0: TUH6): LongInt;
var
  v5: TUH6;
  v6: TUH6;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH8;
  v3: LongInt;
  v4: LongInt;
  v1: TUH7;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_4(v5);
          v8 := 1 + v7;
          v9 := size_4(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_5(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_3(v0: TUH4): LongInt;
var
  v5: TUH4;
  v6: TUH4;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH6;
  v3: LongInt;
  v4: LongInt;
  v1: TUH5;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_3(v5);
          v8 := 1 + v7;
          v9 := size_3(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_4(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_2(v0: TUH2): LongInt;
var
  v5: TUH2;
  v6: TUH2;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH4;
  v3: LongInt;
  v4: LongInt;
  v1: TUH3;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_2(v5);
          v8 := 1 + v7;
          v9 := size_2(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_3(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_1(v0: TUH1): LongInt;
var
  v5: TUH1;
  v6: TUH1;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v2: TUH2;
  v3: LongInt;
  v4: LongInt;
  v1: TUH0;
begin
  case v0.tag of
      2: begin
          v5 := v0.c2_0;
          v6 := v0.c2_1;
          v7 := size_1(v5);
          v8 := 1 + v7;
          v9 := size_1(v6);
          v10 := v8 + v9;
          Result := v10;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := size_2(v2);
          v4 := 1 + v3;
          Result := v4;
      end;
      0: begin
          v1 := v0.c0_0;
          Result := 1;
      end;
  end;
end;
function size_0(v0: TUH10): LongInt;
var
  v4: TUH10;
  v5: TUH10;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v1: TUH1;
  v2: LongInt;
  v3: LongInt;
begin
  case v0.tag of
      1: begin
          v4 := v0.c1_0;
          v5 := v0.c1_1;
          v6 := size_0(v4);
          v7 := 1 + v6;
          v8 := size_0(v5);
          v9 := v7 + v8;
          Result := v9;
      end;
      0: begin
          v1 := v0.c0_0;
          v2 := size_1(v1);
          v3 := 1 + v2;
          Result := v3;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: TUH1;
  v2: TUH0;
  v3: TUH3;
  v4: TUH2;
  v5: TUH1;
  v6: TUH1;
  v7: TUH10;
begin
  v0 := UH0_VZ;
  v1 := UH1_Var(v0);
  v2 := UH0_VZ;
  v3 := UH3_VS(v2);
  v4 := UH2_Var(v3);
  v5 := UH1_Lam(v4);
  v6 := UH1_App(v1, v5);
  v7 := UH10_Lam(v6);
  Result := size_0(v7);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
