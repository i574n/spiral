program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TFun1 = class;
  TFun2 = class;
  TFun3 = class;
  TFun4 = class;
  TUH0 = class;
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
  TFun1 = class(TSpiralRc)
    function Invoke(a0: AnsiString): TUS0; virtual; abstract;
  end;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  Tclosure0 = class(TFun0)  function Invoke(v0: LongInt): TFun1; override; end;
  Tclosure1 = class(TFun1) v0: LongInt; function Invoke(v1: AnsiString): TUS0; override; end;
  TUS1 = record tag: LongInt; c0_0: LongInt; c1_0: AnsiString; end;
  TFun4 = class(TSpiralRc)
    function Invoke(a0: AnsiString): TUS1; virtual; abstract;
  end;
  TFun3 = class(TSpiralRc)
    function Invoke(a0: AnsiString): TFun4; virtual; abstract;
  end;
  TFun2 = class(TSpiralRc)
    function Invoke(a0: LongInt): TFun3; virtual; abstract;
  end;
  Tclosure2 = class(TFun2)  function Invoke(v0: LongInt): TFun3; override; end;
  Tclosure3 = class(TFun3) v0: LongInt; function Invoke(v1: AnsiString): TFun4; override; end;
  Tclosure4 = class(TFun4) v0: LongInt; v1: AnsiString; function Invoke(v2: AnsiString): TUS1; override; end;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: AnsiString; c1_1: TUH0; procedure DropFields; override; end;
function StringSlice(const value: AnsiString; from, upto: Int64): AnsiString;
var len: Int64;
begin
  len := Length(value);
  if (from < 0) or (from > len) or (upto < from - 1) or (upto >= len) then Halt(3);
  if upto < from then Exit('');
  if ((Ord(value[from + 1]) and $C0) = $80) or ((upto + 1 < len) and ((Ord(value[upto + 2]) and $C0) = $80)) then Halt(3);
  Result := Copy(value, from + 1, upto - from + 1);
end;
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
function ClosureCreate1(v0: LongInt): TFun1; forward;
function ClosureCreate0: TFun0; forward;
function ClosureCreate4(v0: LongInt; v1: AnsiString): TFun4; forward;
function ClosureCreate3(v0: LongInt): TFun3; forward;
function ClosureCreate2: TFun2; forward;
function continued_3(v0: TFun0; v1: TFun2; v2: TUS1; v3: TUH0): TUS1; forward;
function starts_4(v0: AnsiString; v1: AnsiString): Boolean; forward;
function valued_then_2(v0: TFun0; v1: TFun2; v2: LongInt; v3: AnsiString; v4: TUH0): TUS1; forward;
function arg_parsed_1(v0: TFun0; v1: TFun2; v2: LongInt; v3: AnsiString; v4: TUH0): TUS1; forward;
function flags_parsed_0(v0: TFun0; v1: TFun2; v2: LongInt; v3: TUH0): TUS1; forward;
function US0_Hit(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_Miss: TUS0;
begin
  Result.tag := 1; 
end;
function Tclosure1.Invoke(v1: AnsiString): TUS0;
var
  v2: Boolean;
  v3: LongInt;
begin
  v2 := v1 = 'frames';
  if v2 then begin
      v3 := v0 + 1;
      Result := US0_Hit(v3);
  end else begin
      Result := US0_Miss;
  end;
  SpiralRelease(Self);
end;
function ClosureCreate1(v0: LongInt): TFun1;
var c: Tclosure1;
begin
  c := Tclosure1.Create; c.v0 := v0;
  Result := c;
end;
function Tclosure0.Invoke(v0: LongInt): TFun1;
begin
  Result := ClosureCreate1(v0);
  SpiralRelease(Self);
end;
function ClosureCreate0: TFun0;
var c: Tclosure0;
begin
  c := Tclosure0.Create; 
  Result := c;
end;
function US1_Good(a0: LongInt): TUS1;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US1_Bad(a0: AnsiString): TUS1;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function Tclosure4.Invoke(v2: AnsiString): TUS1;
var
  v3: Boolean;
  v4: LongInt;
  v6: AnsiString;
begin
  v3 := v1 = 'spi';
  if v3 then begin
      v4 := v0 + 10;
      Result := US1_Good(v4);
  end else begin
      v6 := 'executor is fake, got ' + v2;
      Result := US1_Bad(v6);
  end;
  SpiralRelease(Self);
end;
function ClosureCreate4(v0: LongInt; v1: AnsiString): TFun4;
var c: Tclosure4;
begin
  c := Tclosure4.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function Tclosure3.Invoke(v1: AnsiString): TFun4;
begin
  Result := ClosureCreate4(v0, v1);
  SpiralRelease(Self);
end;
function ClosureCreate3(v0: LongInt): TFun3;
var c: Tclosure3;
begin
  c := Tclosure3.Create; c.v0 := v0;
  Result := c;
end;
function Tclosure2.Invoke(v0: LongInt): TFun3;
begin
  Result := ClosureCreate3(v0);
  SpiralRelease(Self);
end;
function ClosureCreate2: TFun2;
var c: Tclosure2;
begin
  c := Tclosure2.Create; 
  Result := c;
end;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_1);
end;
var UH0_End_shared: TUH0 = nil;
function UH0_End: TUH0;
begin
  if UH0_End_shared = nil then begin UH0_End_shared := TUH0.Create; UH0_End_shared.tag := 0; UH0_End_shared.refc := High(LongInt) div 2; end;
  Result := UH0_End_shared;
end;
function UH0_Word(a0: AnsiString; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function continued_3(v0: TFun0; v1: TFun2; v2: TUS1; v3: TUH0): TUS1;
var
  v6: AnsiString;
  v4: LongInt;
begin
  case v2.tag of
      1: begin
          v6 := v2.c1_0;
          SpiralRelease(v0);
          SpiralRelease(v1);
          SpiralRelease(v3);
          Result := US1_Bad(v6);
      end;
      0: begin
          v4 := v2.c0_0;
          Result := flags_parsed_0(v0, v1, v4, v3);
      end;
  end;
end;
function starts_4(v0: AnsiString; v1: AnsiString): Boolean;
var
  v2: LongInt;
  v3: Boolean;
  v4: AnsiString;
  v5: Boolean;
begin
  v2 := LongInt(Length(v1));
  v3 := 1 < v2;
  if v3 then begin
      v4 := StringSlice(v1, 0, 1);
      v5 := v4 = v0;
      Result := v5;
  end else begin
      Result := False;
  end;
end;
function valued_then_2(v0: TFun0; v1: TFun2; v2: LongInt; v3: AnsiString; v4: TUH0): TUS1;
var
  v18: AnsiString;
  v19: Boolean;
  v24: AnsiString;
  v20: LongInt;
  v21: LongInt;
  v22: AnsiString;
  v23: AnsiString;
  v25: AnsiString;
  v5: AnsiString;
  v6: TUH0;
  v7: TFun3;
  v8: AnsiString;
  v9: Boolean;
  v14: AnsiString;
  v10: LongInt;
  v11: LongInt;
  v12: AnsiString;
  v13: AnsiString;
  v15: TFun4;
  v16: TUS1;
begin
  case v4.tag of
      0: begin
          SpiralRelease(v0);
          SpiralRelease(v1);
          SpiralRelease(v4);
          v18 := '--';
          v19 := starts_4(v18, v3);
          if v19 then begin
              v20 := LongInt(Length(v3));
              v21 := v20 - 1;
              v22 := StringSlice(v3, 2, v21);
              v24 := v22;
          end else begin
              v23 := '';
              v24 := v23;
          end;
          v25 := v24 + ' needs a value';
          Result := US1_Bad(v25);
      end;
      1: begin
          v5 := v4.c1_0;
          v6 := v4.c1_1;
          SpiralRetain(v1);
          SpiralRetain(v6);
          SpiralRelease(v4);
          v7 := v1.Invoke(v2);
          v8 := '--';
          v9 := starts_4(v8, v3);
          if v9 then begin
              v10 := LongInt(Length(v3));
              v11 := v10 - 1;
              v12 := StringSlice(v3, 2, v11);
              v14 := v12;
          end else begin
              v13 := '';
              v14 := v13;
          end;
          SpiralRetain(v7);
          v15 := v7.Invoke(v14);
          SpiralRetain(v15);
          SpiralRelease(v7);
          v16 := v15.Invoke(v5);
          SpiralRelease(v15);
          Result := continued_3(v0, v1, v16, v6);
      end;
  end;
end;
function arg_parsed_1(v0: TFun0; v1: TFun2; v2: LongInt; v3: AnsiString; v4: TUH0): TUS1;
var
  v5: TFun1;
  v6: AnsiString;
  v7: Boolean;
  v12: AnsiString;
  v8: LongInt;
  v9: LongInt;
  v10: AnsiString;
  v11: AnsiString;
  v13: TUS0;
  v14: LongInt;
begin
  SpiralRetain(v0);
  v5 := v0.Invoke(v2);
  v6 := '--';
  v7 := starts_4(v6, v3);
  if v7 then begin
      v8 := LongInt(Length(v3));
      v9 := v8 - 1;
      v10 := StringSlice(v3, 2, v9);
      v12 := v10;
  end else begin
      v11 := '';
      v12 := v11;
  end;
  SpiralRetain(v5);
  v13 := v5.Invoke(v12);
  SpiralRelease(v5);
  case v13.tag of
      0: begin
          v14 := v13.c0_0;
          Result := flags_parsed_0(v0, v1, v2, v4);
      end;
      1: begin
          Result := valued_then_2(v0, v1, v2, v3, v4);
      end;
  end;
end;
function flags_parsed_0(v0: TFun0; v1: TFun2; v2: LongInt; v3: TUH0): TUS1;
var
  v5: AnsiString;
  v6: TUH0;
  v7: AnsiString;
  v8: Boolean;
  v13: AnsiString;
  v9: LongInt;
  v10: LongInt;
  v11: AnsiString;
  v12: AnsiString;
  v14: Boolean;
  v15: AnsiString;
begin
  case v3.tag of
      0: begin
          SpiralRelease(v0);
          SpiralRelease(v1);
          SpiralRelease(v3);
          Result := US1_Good(v2);
      end;
      1: begin
          v5 := v3.c1_0;
          v6 := v3.c1_1;
          SpiralRetain(v6);
          SpiralRelease(v3);
          v7 := '--';
          v8 := starts_4(v7, v5);
          if v8 then begin
              v9 := LongInt(Length(v5));
              v10 := v9 - 1;
              v11 := StringSlice(v5, 2, v10);
              v13 := v11;
          end else begin
              v12 := '';
              v13 := v12;
          end;
          v14 := v13 = '';
          if v14 then begin
              SpiralRelease(v0);
              SpiralRelease(v1);
              SpiralRelease(v6);
              v15 := 'unexpected ' + v5;
              Result := US1_Bad(v15);
          end else begin
              Result := arg_parsed_1(v0, v1, v2, v5, v6);
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TFun2;
  v2: LongInt;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: TUH0;
  v8: TUH0;
  v9: TUH0;
  v10: TUH0;
  v11: TUH0;
  v12: TUS1;
  v13: AnsiString;
  v14: LongInt;
  v15: Boolean;
  v17: LongInt;
begin
  v0 := ClosureCreate0;
  v1 := ClosureCreate2;
  v2 := 0;
  v3 := '--spi';
  v4 := 'a.spi';
  v5 := '--executor';
  v6 := 'gpu';
  v7 := UH0_End;
  SpiralRetain(v7);
  v8 := UH0_Word(v6, v7);
  SpiralRetain(v8);
  SpiralRelease(v7);
  v9 := UH0_Word(v5, v8);
  SpiralRetain(v9);
  SpiralRelease(v8);
  v10 := UH0_Word(v4, v9);
  SpiralRetain(v10);
  SpiralRelease(v9);
  v11 := UH0_Word(v3, v10);
  SpiralRetain(v0);
  SpiralRetain(v1);
  SpiralRetain(v11);
  SpiralRelease(v10);
  v12 := flags_parsed_0(v0, v1, v2, v11);
  SpiralRelease(v0);
  SpiralRelease(v1);
  SpiralRelease(v11);
  case v12.tag of
      1: begin
          v13 := v12.c1_0;
          v14 := LongInt(Length(v13));
          v15 := v14 = 25;
          if v15 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          v17 := v12.c0_0;
          Result := 2;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH0_End_shared <> nil then UH0_End_shared.Free;
  Halt(SpiralExitCode);
end.
