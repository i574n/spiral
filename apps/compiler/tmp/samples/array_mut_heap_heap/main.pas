program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut2 = class;
  TBoxArray0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  THeap1 = record l0: THeap0; l1: LongInt; end;
  TMut2 = class(TSpiralRc) l0: THeap1; end;
  TBoxArray0 = class(TSpiralRc) items: array of TMut2; procedure DropFields; override; end;
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
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function HeapCreate1(a0: THeap0; a1: LongInt): THeap1;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function MutCreate2(a0: THeap1): TMut2;
begin
  Result := TMut2.Create; Result.l0 := a0;
end;
procedure TBoxArray0.DropFields;
var i: Int64;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: THeap1;
  v5: TMut2;
  v6: TBoxArray0;
  tmp7: TBoxArray0;
  v7: LongInt;
  v8: AnsiString;
  v9: THeap0;
  v10: LongInt;
  v11: THeap1;
  v12: TMut2;
  v13: THeap1;
  v14: THeap0;
  v15: LongInt;
  v16: LongInt;
  v17: AnsiString;
  v18: Boolean;
  v20: Boolean;
  v19: Boolean;
  v22: Boolean;
  v21: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 1;
  v4 := HeapCreate1(v2, v3);
  v5 := MutCreate2(v4);
  tmp7 := TBoxArray0.Create;
  SetLength(tmp7.items, 1);
  v6 := tmp7;
  SpiralRetain(v5); SpiralRelease(v6.items[0]); v6.items[0] := v5;
  SpiralRelease(v5);
  v7 := 7;
  v8 := 'hi';
  v9 := HeapCreate0(v7, v8);
  v10 := 4;
  v11 := HeapCreate1(v9, v10);
  v12 := v6.items[0];
  SpiralRetain(v12);
  SpiralRelease(v6);
  v12.l0 := v11;
  v13 := v12.l0;
  SpiralRelease(v12);
  v14 := v13.l0;
  v15 := v13.l1;
  v16 := v14.l0;
  v17 := v14.l1;
  v18 := v16 = 7;
  if v18 then begin
      v19 := v17 = 'hi';
      v20 := v19;
  end else begin
      v20 := False;
  end;
  if v20 then begin
      v21 := v15 = 4;
      v22 := v21;
  end else begin
      v22 := False;
  end;
  if v22 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
